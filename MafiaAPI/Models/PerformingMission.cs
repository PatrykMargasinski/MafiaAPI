using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MafiaAPI.Models
{
    public partial class PerformingMission
    {
        public int PerformingMissionId { get; set; }
        public int? MissionId { get; set; }
        public int? AgentId { get; set; }
        public DateTime? CompletionTime { get; set; }
        [ForeignKey("AgentId")]
        public virtual Agent Agent { get; set; }
        [ForeignKey("MissionId")]
        public virtual Mission Mission { get; set; }
    }
}
