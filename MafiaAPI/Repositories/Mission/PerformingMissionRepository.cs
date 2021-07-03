using MafiaAPI.Models;
using MafiaAPI.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MafiaAPI.Repositories
{

    public class PerformingMissionRepository : CrudRepository<PerformingMission>, IPerformingMissionRepository
    {


        public PerformingMissionRepository(MafiaDBContext context) : base(context) { }

        public new PerformingMission GetById(long id)
        {
            return _context.PerformingMissions
                .Include(p => p.Mission)
                .Include(p => p.Agent)
                .FirstOrDefault(PerformingMission => PerformingMission.Id == id);
        }

        public new IQueryable<PerformingMission> GetAllWithMissionAndAgent()
        {
            return _context.PerformingMissions
                .Include(p => p.Mission)
                .Include(p => p.Agent);
        }

        public IEnumerable<PerformingMission> GetByAgentId(long id)
        {
            return _context.PerformingMissions.Where(x => x.Id == id);
        }
    }
}
