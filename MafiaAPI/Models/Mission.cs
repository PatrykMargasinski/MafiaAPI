using System;
using System.Collections.Generic;

#nullable disable

namespace MafiaAPI.Models
{
    public partial class Mission
    {
        public Mission()
        {
            PerformingMissions = new HashSet<PerformingMission>();
        }

        public int MissionId { get; set; }
        public string MissionName { get; set; }
        public int? DifficultyLevel { get; set; }
        public int? Loot { get; set; }

        public virtual ICollection<PerformingMission> PerformingMissions { get; set; }
    }
}
