using System;
using System.Linq;
using Castle.Core.Internal;
using MafiaAPI.Models;
using MafiaAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MafiaAPI.Service
{

    public class PerformingMissionService : IPerformingMissionService
    {
        private IPerformingMissionRepository _pmRepository;

        public PerformingMissionService(IPerformingMissionRepository pmRepository)
        {
            _pmRepository = pmRepository;
        }
        public long CreateAndGetId(long missionId, long agentId, DateTime finishTime)
        {
            PerformingMission pm = new PerformingMission{
                MissionId = missionId,
                AgentId = agentId,
                CompletionTime = finishTime
            };

            return _pmRepository.CreateGetId(pm);
        }

        public bool IsOnMission(long agentId) 
        {
            return _pmRepository
                .GetByAgentId(agentId)
                .ToList()
                .IsNullOrEmpty();
            
        }

        public PerformingMission GetById(long id)
        {
            return _pmRepository.GetById(id);
        }

        public void Delete(PerformingMission pm)
        {
            _pmRepository.Delete(pm);
        }
    }

}