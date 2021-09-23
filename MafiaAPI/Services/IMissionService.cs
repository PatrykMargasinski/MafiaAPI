using Microsoft.AspNetCore.Mvc;
using Quartz;

namespace MafiaAPI.Service
{

    public interface IMissionService
    {
        public IActionResult DoMission(long agentId, long missionId);
        public void EndMission(long pmId);
        public void GenerateMissions();
    }
}