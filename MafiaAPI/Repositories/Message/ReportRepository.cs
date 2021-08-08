using MafiaAPI.Models;
using System.Linq;
using MafiaAPI.Database;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MafiaAPI.Repositories
{

    public class ReportRepository : CrudRepository<Report>, IReportRepository
    {

        public ReportRepository(MafiaDBContext context) : base(context) { }

        public IList<Report> GetAllReportsTo(long bossId, int fromRange = 0, int toRange = 5, bool onlyUnseen = false)
        {
            return _context.Reports
                .Include(x => x.ToBoss)
                .Where(mes =>
                mes.ToBossId == bossId &&
                    (!mes.Seen || !onlyUnseen) //get only unseen reports if "onlyUnseen" is true
                )
                .OrderByDescending(x => x.ReceivedDate)
                .Skip(fromRange)
                .Take(toRange - fromRange)
                .ToList();
        }

        public int CountReportsTo(long bossId)
        {
            return _context.Reports
                .Where(x => x.ToBossId == bossId)
                .Count();
        }
    }
}
