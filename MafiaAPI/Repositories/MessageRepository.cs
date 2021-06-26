using MafiaAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public Message Get(int id)
        {
            var message = _context.Messages.FirstOrDefault(x => x.MessageId == id);
            return message;
        }

        public IEnumerable<Message> GetAllMessageTo(int bossId)
        {
            var messages = _context
                .Messages
                .Include(m => m.ToBoss)
                .Include(p => p.FromBoss)
                .Where(x => x.ToBossId == bossId);
            return messages;
        }

        public IEnumerable<Message> GetAllMessageFrom(int bossId)
        {
            var messages = _context.Messages.Where(x => x.FromBossId == bossId);
            return messages;
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

        public void Update(Message newMessage)
        {
            var updatingMessage = _context.Messages.FirstOrDefault(x => x.MessageId == newMessage.MessageId);
            if (newMessage != null && updatingMessage != null)
            {
                updatingMessage.MessageId = newMessage.MessageId;
                updatingMessage.FromBoss = newMessage.FromBoss;
                updatingMessage.ToBoss = newMessage.ToBoss;
                updatingMessage.Content = newMessage.Content;
                _context.SaveChanges();
            }
        }
    }
}
