using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    
    public class MessageRepository : CrudRepository<Message>, IMessageRepository
    {
        
        public MessageRepository(MafiaDBContext context): base(context){}

        public IQueryable<Message> GetAllMessagesTo(long bossId)
        {
            return _context.Messages.Where(mes => mes.BossId == bossId);
        }
        public IQueryable<Message> GetAllMessagesFrom(long bossId)
        {
            return _context.Messages.Where(mes => mes.BossId == bossId);
        }
    }
}
