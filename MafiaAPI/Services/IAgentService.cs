using MafiaAPI.Repositories;

namespace MafiaAPI.Service
{
    public interface IAgentService
    {
        public string RecruitAgent(long bossId, long agentId);
        bool HasBoss(long agentId);
        bool Exist(long agentId);
    }

    
}
