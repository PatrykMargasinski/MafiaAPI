using System;
using System.Collections.Generic;

#nullable disable

namespace MafiaAPI.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int? ToBossId { get; set; }
        public int? FromBossId { get; set; }
        public string Content { get; set; }

        public virtual Boss FromBoss { get; set; }
        public virtual Boss ToBoss { get; set; }
    }
}
