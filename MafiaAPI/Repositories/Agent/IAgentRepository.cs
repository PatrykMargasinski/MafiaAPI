using MafiaAPI.Models;
using System.Collections.Generic;

namespace MafiaAPI.Repositories
{
    public interface IAgentRepository : ICrudRepository<Agent>
    {
        public IList<Agent> GetAvailableAgents(long bossId);
        public IList<Agent> GetAgentsForSale();
        public IList<Agent> GetBossAgents(long id);
        public IList<Agent> GetAgentsOnMission(long bossId);
    }
}
