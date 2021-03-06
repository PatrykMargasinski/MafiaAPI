using MafiaAPI.Database;
using MafiaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MafiaAPI.Repositories
{

    public class AgentForSaleRepository : CrudRepository<AgentForSale>, IAgentForSaleRepository
    {
        public AgentForSaleRepository(MafiaDBContext context) : base(context) { }
        public IList<AgentForSaleDTO> GetAgentsForSale()
        {
            return _context
                .AgentsForSale
                .Include(x => x.Agent)
                .Select(x => new AgentForSaleDTO()
                {
                    Id = x.AgentId,
                    FirstName = x.Agent.FirstName,
                    LastName = x.Agent.LastName,
                    Strength = x.Agent.Strength,
                    Dexterity = x.Agent.Dexterity,
                    Intelligence = x.Agent.Intelligence,
                    Price = x.Price
                })
                .ToList();
        }

        public AgentForSale GetByAgentId(long agentId)
        {
            return _context
                .AgentsForSale
                .Where(x => x.AgentId == agentId)
                .FirstOrDefault();
        }
    }
}
