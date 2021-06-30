using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{

    public interface IMessageRepository
    {
<<<<<<< HEAD:MafiaAPI/Repositories/Message/IMessageRepository.cs
        public IQueryable<Message> GetAllMessagesTo(int bossId);
=======
        public IEnumerable<Message> GetAllMessageTo(int bossId);
        public IEnumerable<Message> GetAllMessageFrom(int bossId);
        public Message Get(int id);
        public void Post(Message message);
        public void Update(Message newMessage);
        public void Delete(int id);
>>>>>>> 06069cfbb38b554f986aabdb55117282a8ba84b1:MafiaAPI/Repositories/IMessageRepository.cs
    }
}
