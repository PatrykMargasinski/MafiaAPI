using MafiaAPI.Models;
using System.Collections.Generic;

namespace MafiaAPI.Repositories
{
    public interface IMissionRepository : ICrudRepository<Mission>
    {
        public IList<Mission> GetAvailableMissions();

    }
}
