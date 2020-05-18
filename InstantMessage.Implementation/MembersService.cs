using InstantMessage.DataModel.InstantMessageDB;
using InstantMessage.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstantMessage.Service
{
    public class MembersService : BaseRepositoryService<Members>, IMembersService
    {
        public MembersService(ImDbContext db):base(db)
        { 
        
        }
    }
}
