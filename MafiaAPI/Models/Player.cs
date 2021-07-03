using System;
using System.Collections.Generic;

#nullable disable

namespace MafiaAPI.Models
{
    public partial class Player : Model
    {
        public string Nick { get; set; }
        public string Password { get; set; }
        public long BossId { get; set; }
        public virtual Boss Boss { get; set; }
    }
}
