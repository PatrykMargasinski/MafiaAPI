using System;
using System.Collections.Generic;

#nullable disable

namespace MafiaAPI.Models
{
    public partial class Message : Model
    {
<<<<<<< HEAD
        public long? BossId { get; set; }
=======
        public int MessageId { get; set; }
        public int? ToBossId { get; set; }
        public int? FromBossId { get; set; }
>>>>>>> 06069cfbb38b554f986aabdb55117282a8ba84b1
        public string Content { get; set; }

        public virtual Boss FromBoss { get; set; }
        public virtual Boss ToBoss { get; set; }
    }
}
