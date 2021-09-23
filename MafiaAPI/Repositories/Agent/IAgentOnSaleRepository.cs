using MafiaAPI.Models;
using System.Collections.Generic;

namespace MafiaAPI.Repositories
{
    public interface IAgentForSaleRepository : ICrudRepository<AgentForSale>
    {
        public IList<AgentForSaleDTO> GetAgentsForSale();
        public AgentForSale GetByAgentId(long agentId);
    }
}
