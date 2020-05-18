using System;
using System.Collections.Generic;

namespace InstantMessage.DataModel.InstantMessageDB
{
    public partial class Messages
    {
        public long Id { get; set; }
        public long FromMemberId { get; set; }
        public long ToMemberId { get; set; }
        public string Message { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
