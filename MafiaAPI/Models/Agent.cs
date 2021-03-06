using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Models
{
    public class Agent
    {
        public int AgentId { get; set; }
        public int BossId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Strength { get; set; }
        public int Income { get; set; }
    }
}
