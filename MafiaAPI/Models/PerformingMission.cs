using System;
using System.Collections.Generic;

#nullable disable

namespace MafiaAPI.Models
{
    public partial class PerformingMission
    {
        public int PerformingMissionId { get; set; }
        public int? MissionId { get; set; }
        public int? AgentId { get; set; }
        public DateTime? CompletionTime { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual Mission Mission { get; set; }
    }
}
