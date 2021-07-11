using MafiaAPI.Repositories;

namespace MafiaAPI.Service
{
    public interface IAgentService
    {
        bool HasBoss(long agentId);
        bool Exist(long agentId);
    }

    
}
