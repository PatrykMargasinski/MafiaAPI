using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{

    public interface IMessageRepository
    {
        public IQueryable<Message> GetAllMessagesTo(int bossId);
        public void Post(Message message);
        public void Delete(int messageId);
    }
}
