using MafiaAPI.Database;
using MafiaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MafiaAPI.Repositories
{

    public class MessageRepository : CrudRepository<Message>, IMessageRepository
    {

        public MessageRepository(MafiaDBContext context) : base(context) { }

        public IList<Message> GetAllMessagesTo(long bossId, int fromRange = 0, int toRange = 5, string bossNameFilter = "", bool onlyUnseen = false)
        {
            return _context.Messages
                .Include(x => x.ToBoss)
                .Include(x => x.FromBoss)
                .Where(mes =>
                mes.ToBossId == bossId && (
                    (mes.FromBoss.FirstName + mes.FromBoss.LastName).ToLower().Contains(bossNameFilter.Trim().ToLower()) ||
                    (mes.FromBoss.LastName + mes.FromBoss.FirstName).ToLower().Contains(bossNameFilter.Trim().ToLower())
                ) &&
                    (!mes.Seen || !onlyUnseen) //get only unseen messages if "onlyUnseen" is true
                )
                .OrderByDescending(x => x.ReceivedDate)
                .Skip(fromRange)
                .Take(toRange - fromRange)
                .ToList();
        }

        public int CountMessagesTo(long bossId)
        {
            return _context.Messages
                .Where(x => x.ToBossId == bossId)
                .Count();
        }
    }
}
