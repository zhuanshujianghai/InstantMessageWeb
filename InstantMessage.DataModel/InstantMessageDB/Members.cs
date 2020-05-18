using System;
using System.Collections.Generic;

namespace InstantMessage.DataModel.InstantMessageDB
{
    public partial class Members
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
        public string ConnectionId { get; set; }
        public DateTime CreateTime { get; set; }
        public int Status { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
