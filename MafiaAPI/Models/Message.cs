using System;
using System.Collections.Generic;

#nullable disable

namespace MafiaAPI.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int? BossId { get; set; }
        public string Content { get; set; }
        public virtual Boss Boss { get; set; }
    }
}
