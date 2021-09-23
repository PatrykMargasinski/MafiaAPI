using MafiaAPI.Service;
using System;

namespace MafiaAPI.Models
{

    public class PerformingMissionDTO
    {
        public long Id { get; set; }
        public string MissionName { get; set; }
        public string AgentName { get; set; }

        public double SuccessChance { get; set; }

        public DateTime EndTime { get; set; }

        public PerformingMissionDTO(PerformingMission pm)
        {
            this.Id = pm.Id;
            this.MissionName = pm.Mission.Name;
            this.AgentName = pm.Agent.getName();
            this.SuccessChance = MissionService.CalculateMissionSuccessRate(pm.Mission, pm.Agent);
            this.EndTime = pm.CompletionTime.Value;
        }

    }
}
