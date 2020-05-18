using InstantMessage.DataModel.InstantMessageDB;
using InstantMessage.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstantMessage.Service
{
    public class MessagesService : BaseRepositoryService<Messages>, IMessagesService
    {
        public MessagesService(ImDbContext db) : base(db)
        {

        }
    }
}
