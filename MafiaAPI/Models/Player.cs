using System;
using System.Collections.Generic;

#nullable disable

namespace MafiaAPI.Models
{
    public partial class Player
    {
        public int PlayerId { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public int BossId { get; set; }

        public virtual Boss Boss { get; set; }
    }
}
