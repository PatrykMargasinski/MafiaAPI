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
                .ToList();
        }
        public IList<Message> GetAllMessagesFrom(long bossId)
        {
            return _context.Messages
                .Include(x => x.ToBoss)
                .Include(x => x.FromBoss)
                .Where(mes => mes.FromBossId == bossId)
                .ToList();
        }
    }
}
