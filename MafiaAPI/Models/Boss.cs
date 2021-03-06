using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Models
{
    public class Boss
    {
        public int BossId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Money { get; set; }
        public string LastSeen { get; set; }
    }
}
