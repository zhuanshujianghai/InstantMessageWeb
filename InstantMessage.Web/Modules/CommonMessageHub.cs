using InstantMessage.Common;
using InstantMessage.DataModel.InstantMessageDB;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstantMessage.Web.Modules
{
    public class CommonMessageHub : Hub
    {
        public string CurrentConnectionId;
        public static List<User> users = new List<User>();

        /// <summary>
        /// 根据Id发送信息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string username, string message)
        {
            var user = users.Where(s => s.UserName == username).FirstOrDefault();
            if (user != null)
            {
                var userself = users.Where(s => s.ConnectionID == Context.ConnectionId).FirstOrDefault();
                string sendUser;
                if (userself != null)
                {
                    sendUser = userself.UserName;
                }
                else
                {
                    sendUser = "未知用户";
                }
                //发动信息给对方
                await Clients.Client(user.ConnectionID).SendAsync("ReceiveMessage", sendUser, message);
                //给自己发送，把用户的ID传给自己
                await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", sendUser, message);
            }
            else
            {
                await Clients.Client(Context.ConnectionId).SendAsync("该用户已离线");
            }
        }

        /// <summary>
        /// 广播发送信息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessageAll(string message)
        {
            var user = users.Where(s => s.ConnectionID == Context.ConnectionId).FirstOrDefault();
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
        /// <summary>
        /// 初次加入广播
        /// </summary>
        /// <returns></returns>
        public async Task SendMessageAllFirst()
        {
            var user = users.Where(s => s.ConnectionID == Context.ConnectionId).FirstOrDefault();
            string sendUser;
            if (user != null)
            {
                sendUser = user.UserName;
            }
            else
            {
                sendUser = "未知用户";
            }
            await Clients.AllExcept(Context.ConnectionId).SendAsync("ReceiveMessage", user.UserName, "大家好，我是"+ sendUser);
        }

        /// <summary>
        /// 重写连接事件
        /// </summary>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {
            CurrentConnectionId = Context.ConnectionId;
            //查询用户
            var user = users.Where(w => w.ConnectionID == Context.ConnectionId).SingleOrDefault();
            //判断用户是否存在，否则添加集合
            if (user == null)
            {
                user = new User(CreateUserName(), Context.ConnectionId);
                users.Add(user);
            }
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception ex)
        {
            var user = users.Where(p => p.ConnectionID == Context.ConnectionId).FirstOrDefault();
            //判断用户是否存在，存在则删除
            if (user != null)
            {
                //删除用户
                users.Remove(user);
            }
            return base.OnDisconnectedAsync(ex);
        }

        private string CreateUserName()
        {
            string str1 = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;
            string[] dieci = { "坏坏", "风风","火火","后后","凉凉","亮亮","天天" };
            string[] lianci = { "但","又","且","还","就","或"};
            string[] mingci = { "立春","雨水","惊蛰","春分","清明","谷雨","立夏","小满","芒种","夏至","小暑","大暑","立秋","处暑","白露","秋分","寒露","霜降","立冬","小雪","大雪","冬至","小寒","大寒"};

            Random rd = new Random();
            int num1 = rd.Next(dieci.Length);
            int num2 = rd.Next(lianci.Length);
            int num3 = rd.Next(mingci.Length);
            str1 = dieci[num1];
            str2 = lianci[num2];
            str3 = mingci[num3];
            
            int count = rd.Next(100);
            return str1+str2+str3+count;
        }
    }
    public class User
    {
        public string UserName { get; set; }
        public string ConnectionID { get; set; }
        public User(string name, string connectionId)
        {
            this.UserName = name;
            this.ConnectionID = connectionId;
        }

    }
}
