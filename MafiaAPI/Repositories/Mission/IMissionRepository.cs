using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    public interface IMissionRepository
    {
        public IEnumerable<Mission> GetAll();
        public IEnumerable<Mission> GetAvailableMissions();
        public Mission Get(int id);
        public void Post(Mission agent);
        public void Update(Mission newMission);
        public void Delete(int id);
    }
}
