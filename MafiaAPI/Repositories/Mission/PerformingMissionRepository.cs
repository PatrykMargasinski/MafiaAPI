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

        public IList<PerformingMission> GetAllWithMissionAndAgent()
        {
            return _context.PerformingMissions
                .Include(p => p.Mission)
                .Include(p => p.Agent)
                .ToList();
        }
        public IList<PerformingMission> GetAllWithMissionAndAgentByBossId(long bossId)
        {
            return _context.PerformingMissions
                .Include(p => p.Mission)
                .Include(p => p.Agent)
                .Where(x => x.Agent.BossId == bossId)
                .ToList();
        }

        public IList<PerformingMission> GetByAgentId(long id)
        {
            return _context.PerformingMissions
                .Where(x => x.Id == id)
                .ToList();
        }
    }
}
