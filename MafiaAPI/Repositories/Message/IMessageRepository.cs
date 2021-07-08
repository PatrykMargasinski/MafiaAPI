using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Repositories
{

    public interface IMessageRepository : ICrudRepository<Message>
    {
        public IList<Message> GetAllMessagesTo(long bossId);
        public IList<Message> GetAllMessagesFrom(long bossId);
    }
}
