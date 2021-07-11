using System;
using MafiaAPI.Repositories;

namespace MafiaAPI.Service
{
    public class AgentService: IAgentService
    {
        IAgentRepository _agentRepository;

        public AgentService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public bool HasBoss(long agentId)
        {
            return _agentRepository
                .GetById(agentId).HasBoss();
        }

        public bool Exist(long agentId)
        {
            return _agentRepository.GetById(agentId) != null;
        }
    }
}