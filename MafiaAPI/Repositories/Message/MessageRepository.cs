using MafiaAPI.Models;
using System.Linq;
using MafiaAPI.Database;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MafiaAPI.Repositories
{

    public class MessageRepository : CrudRepository<Message>, IMessageRepository
    {

        public MessageRepository(MafiaDBContext context) : base(context) { }

        public IList<Message> GetAllMessagesTo(long bossId)
        {
            return _context.Messages
                .Include(x => x.ToBoss)
                .Include(x => x.FromBoss)
                .Where(mes => mes.ToBossId == bossId)
                .OrderByDescending(x=>x.ReceiveDate)
                .ToList();
        }
        public IList<Message> GetAllMessagesFrom(long bossId)
        {
            return _context.Messages
                .Include(x => x.ToBoss)
                .Include(x => x.FromBoss)
                .Where(mes => mes.FromBossId == bossId)
                .OrderByDescending(x => x.ReceiveDate)
                .ToList();
        }
        public IList<Message> GetAllMessagesToRange(long bossId, int fromRange, int toRange, string bossNameFilter)
        {
            return _context.Messages
                .Include(x => x.ToBoss)
                .Include(x => x.FromBoss)
                .Where(mes => 
                mes.ToBossId == bossId && (
                (mes.FromBoss.FirstName + mes.FromBoss.LastName).ToLower().Contains(bossNameFilter.Trim().ToLower()) ||
                (mes.FromBoss.LastName + mes.FromBoss.FirstName).ToLower().Contains(bossNameFilter.Trim().ToLower())
                ))
                .OrderByDescending(x => x.ReceiveDate)
                .Skip(fromRange)
                .Take(toRange - fromRange)
                .ToList();
        }
        public IList<Message> GetAllMessagesFromRange(long bossId, int fromRange, int toRange)
        {
            return _context.Messages
                .Include(x => x.ToBoss)
                .Include(x => x.FromBoss)
                .Where(mes => mes.FromBossId == bossId)
                .OrderByDescending(x => x.ReceiveDate)
                .Skip(fromRange)
                .Take(toRange-fromRange)
                .ToList();
        }

        public int GetMessageToCount(long bossId)
        {
            return _context.Messages
                .Where(x => x.ToBossId == bossId)
                .Count();
        }
    }
}
