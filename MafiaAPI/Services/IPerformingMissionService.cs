using MafiaAPI.Models;
using System;

namespace MafiaAPI.Service
{

    public interface IPerformingMissionService
    {
        long CreateAndGetId(long missionId, long agentId, DateTime finishTime);
        bool IsOnMission(long agentId);

        PerformingMission GetById(long pmId);

        void Delete(PerformingMission pm);
    }
}