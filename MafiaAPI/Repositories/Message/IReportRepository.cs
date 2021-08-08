using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{

    public interface IReportRepository : ICrudRepository<Report>
    {
        public IList<Report> GetAllReportsTo(long bossId, int fromRange, int toRange, bool onlyUnseen);
        public int CountReportsTo(long bossId);
    }
}
