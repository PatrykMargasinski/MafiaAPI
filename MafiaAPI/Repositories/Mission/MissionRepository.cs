using MafiaAPI.Database;
using MafiaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MafiaAPI.Repositories
{

    public class MissionRepository : CrudRepository<Mission>, IMissionRepository
    {

        public MissionRepository(MafiaDBContext context) : base(context) { }

        public IList<Mission> GetAvailableMissions()
        {
            return _context.Missions
                .Include(x => x.PerformingMissions)
                .Where(mission => !mission.PerformingMissions.Any())
                .ToList();
        }

    }
}
