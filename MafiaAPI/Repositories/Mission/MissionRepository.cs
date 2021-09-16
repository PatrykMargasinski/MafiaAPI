using MafiaAPI.Models;
using MafiaAPI.Database;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MafiaAPI.Repositories
{
    
    public class MissionRepository : CrudRepository<Mission>, IMissionRepository
    {

        public MissionRepository(MafiaDBContext context): base(context){}

        public IList<Mission> GetAvailableMissions()
        {
            return _context.Missions
                .Include(x=>x.PerformingMissions)
                .Where(mission => !mission.PerformingMissions.Any())
                .ToList();
        }

        public IList<MissionType> GetMissionTypes()
        {
            return _context
                .MissionTypes
                .ToList();
        }

    }
}
