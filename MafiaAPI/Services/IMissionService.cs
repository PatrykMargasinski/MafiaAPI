using Microsoft.AspNetCore.Mvc;

namespace MafiaAPI.Service
{

    public interface IMissionService
    {
        public IActionResult DoMission(long agentId, long missionId);
        public void EndMission(long pmId);
    }
}