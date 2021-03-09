using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    
    public class PerformingMissionRepository : IPerformingMissionRepository
    {
        private readonly MafiaDBContext _context;

        public PerformingMissionRepository(MafiaDBContext context)
        {
            _context = context;
        }
        public PerformingMission Get(int id)
        {
            return _context.PerformingMissions.FirstOrDefault(PerformingMission => PerformingMission.PerformingMissionId == id);
        }

        public IEnumerable<PerformingMission> GetAll()
        {
            return _context.PerformingMissions;
        }

        public void Post(PerformingMission mission)
        {
            if(mission!=null)
            {
                _context.PerformingMissions.Add(mission);
                _context.SaveChanges();
            }
        }

        public void Update(PerformingMission newPerformingMission)
        {
            var updatingPerformingMission = _context.PerformingMissions.FirstOrDefault(mission => mission.PerformingMissionId == newPerformingMission.PerformingMissionId);
            if (newPerformingMission!=null && updatingPerformingMission!=null)
            {
                updatingPerformingMission.MissionId= newPerformingMission.MissionId;
                updatingPerformingMission.AgentId = newPerformingMission.AgentId;
                updatingPerformingMission.CompletionTime = newPerformingMission.CompletionTime;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var deletingPerformingMission = _context.PerformingMissions.FirstOrDefault(mission => mission.PerformingMissionId == id);
            _context.Remove(deletingPerformingMission);
            _context.SaveChanges();
        }
    }
}
