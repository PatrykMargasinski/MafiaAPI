using System;
using System.Collections.Generic;

#nullable disable

namespace MafiaAPI.Models
{
    public partial class Message : Model
    {
        public long? ToBossId { get; set; }
        public long? FromBossId { get; set; }
        public string Content { get; set; }
        public DateTime ReceiveDate { get; set; }
        public virtual Boss FromBoss { get; set; }
        public virtual Boss ToBoss { get; set; }
    }
}
