using System;
using System.Collections.Generic;

#nullable disable

namespace MafiaAPI.Models
{
    public partial class Agent
    {
        public Agent()
        {
            PerformingMissions = new HashSet<PerformingMission>();
        }

        public int AgentId { get; set; }
        public int? BossId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? Strength { get; set; }
        public int? Income { get; set; }

        public virtual Boss Boss { get; set; }
        public virtual ICollection<PerformingMission> PerformingMissions { get; set; }
    }
}
