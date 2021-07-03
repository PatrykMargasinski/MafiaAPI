using System;

#nullable disable

namespace MafiaAPI.Models
{
    public partial class PerformingMission : Model
    {
        public long? MissionId { get; set; }
        public long? AgentId { get; set; }
        public DateTime? CompletionTime { get; set; }
        public virtual Agent Agent { get; set; }
        public virtual Mission Mission { get; set; }
    }
}
