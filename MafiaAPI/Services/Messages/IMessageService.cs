using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Services.Messages
{
    public interface IMessageService
    {
        public void SendMessage(Message message);
        public void SendMessage(string fromBossName, string toBossName, string content);
    }
}
