using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Models
{
    public class PerformingMission
    {
        public int PerformingMissionId { get; set; }
        public int MissionId { get; set; }
        public int AgentId { get; set; }
        public string CompletionTime { get; set; }
    }
}
