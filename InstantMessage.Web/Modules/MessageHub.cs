using InstantMessage.Common;
using InstantMessage.DataModel.InstantMessageDB;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstantMessage.Web.Modules
{
    public class MessageHub : Hub
    {
        public string CurrentConnectionId;

        public async Task Register(string username)
        {
            using (ImDbContext db = new ImDbContext())
            {
                var member = db.Members.SingleOrDefault(a => a.UserName == username);
                if (member == null)
                {
                    //查询当前连接是否存在数据，不存在则添加
                    member = db.Members.SingleOrDefault(a => a.ConnectionId == Context.ConnectionId);
                    if (member == null)
                    {
                        member = new Members
                        {
                            Id = IdGenerator.GetSnowflakeID(),
                            ConnectionId = username,
                            UserName = Context.ConnectionId,
                            CreateTime = DateTime.Now,
                            Status = 1,
                        };
                        db.Members.Add(member);
                        db.SaveChanges();
                    }
                }
                else
                {
                    await base.OnDisconnectedAsync(new Exception());
                    //提示信息
                    await Clients.Client(Context.ConnectionId).SendAsync("ReceiveAlertMessage", "用户名已存在");
                }
            }
        }

        /// <summary>
        /// 根据Id发送信息
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string username, string message)
        {
            using (ImDbContext db = new ImDbContext())
            {
                var user = db.Members.Where(s => s.UserName == username && s.Status==1).FirstOrDefault();
                var userself = db.Members.Where(s => s.ConnectionId == Context.ConnectionId).FirstOrDefault();

                string sendUser;
                if (userself != null)
                {
                    sendUser = userself.UserName;
                }
                else
                {
                    sendUser = "未知用户";
                }
                if (user != null)
                {
                    //发动信息给对方
                    await Clients.Client(user.ConnectionId).SendAsync("ReceiveMessage", sendUser, message);
                    //给自己发送，把用户的ID传给自己
                    await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", sendUser, message);
                }
                else
                {
                    await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", sendUser, "发送失败，对方已离线");
                }
            }
                
            
        }

        /// <summary>
        /// 广播发送信息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessageAll(string message)
        {
            using (ImDbContext db = new ImDbContext())
            {
                var user = db.Members.Where(s => s.ConnectionId == Context.ConnectionId).FirstOrDefault();
                string sendUser;
                if (user != null)
                {
                    sendUser = user.UserName;
                }
                else
                {
                    sendUser = "未知用户";
                }
                await Clients.All.SendAsync("ReceiveMessage", user.UserName, message);
            }  
        }

        /// <summary>
        /// 重写连接事件
        /// </summary>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {
            using (ImDbContext db = new ImDbContext())
            {
                return base.OnConnectedAsync();
            }
                
        }
        public override Task OnDisconnectedAsync(Exception ex)
        {
            using (ImDbContext db = new ImDbContext())
            {
                var user = db.Members.Where(p => p.ConnectionId == Context.ConnectionId).FirstOrDefault();
                //判断用户是否存在，存在则离线
                if (user != null)
                {
                    user.Status = 0;
                    db.Members.Update(user);
                    db.SaveChanges();
                }
                return base.OnDisconnectedAsync(ex);
            }
        }
    }
    
}
