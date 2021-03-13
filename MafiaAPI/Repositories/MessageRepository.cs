using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{
    
    public class MessageRepository : IMessageRepository
    {
        private readonly MafiaDBContext _context;

        public MessageRepository(MafiaDBContext context)
        {
            _context = context;
        }

        public IQueryable<Message> GetAllMessagesTo(int bossId)
        {
            return _context.Messages.Where(mes => mes.BossId == bossId);
        }

        public void Post(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public void Delete(int messageId)
        {
            var deletingMessage = _context.Messages.FirstOrDefault(mes => mes.MessageId == messageId);
            _context.Remove(deletingMessage);
            _context.SaveChanges();
        }
    }
}
