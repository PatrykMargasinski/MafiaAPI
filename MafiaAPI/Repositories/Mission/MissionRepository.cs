using MafiaAPI.Models;
using MafiaAPI.Database;
using System.Collections.Generic;
using System.Linq;

namespace MafiaAPI.Repositories
{
    
    public class MissionRepository : CrudRepository<Mission>, IMissionRepository
    {

        public MissionRepository(MafiaDBContext context): base(context){}

        public IEnumerable<Mission> GetAvailableMissions()
        {
            return _context.Missions.Where(mission => mission.PerformingMissions.Count == 0);
        }

    }
}
