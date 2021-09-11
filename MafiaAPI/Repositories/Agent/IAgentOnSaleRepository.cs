using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IAgentForSaleRepository: ICrudRepository<AgentForSale>
    {
        public IList<AgentForSaleDTO> GetAgentsForSale();
        public AgentForSale GetByAgentId(long agentId);
    }
}
