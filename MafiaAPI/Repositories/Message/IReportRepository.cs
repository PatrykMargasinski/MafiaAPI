using MafiaAPI.Models;
using System.Collections.Generic;

namespace MafiaAPI.Repositories
{

    public interface IReportRepository : ICrudRepository<Report>
    {
        public IList<Report> GetAllReportsTo(long bossId, int fromRange, int toRange, bool onlyUnseen);
        public int CountReportsTo(long bossId);
    }
}
