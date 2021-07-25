using System;
using System.Collections.Generic;

#nullable disable

namespace MafiaAPI.Models
{
    public partial class Agent : Model
    {
        public Agent()
        {
            PerformingMissions = new HashSet<PerformingMission>();
        }

        public long? BossId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int? Income { get; set; }

        public virtual Boss Boss { get; set; }
        public virtual ICollection<PerformingMission> PerformingMissions { get; set; }

        public bool HasBoss() { return BossId.HasValue; }

        public String getName() { return this.FirstName + " " + this.LastName; }
    }
}
