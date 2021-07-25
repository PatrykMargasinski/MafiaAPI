using MafiaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MafiaAPI.Database;
using MafiaAPI.Repositories;

namespace MafiaAPI.Services.Messages
{

    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IBossRepository _bossRepository;
        private readonly ISecurityService _securityService;
        public MessageService(IMessageRepository messageRepository, IBossRepository bossRepository, ISecurityService securityService)
        {
            _messageRepository = messageRepository;
            _bossRepository = bossRepository;
            _securityService = securityService;
        }
        public void SendMessage(Message message)
        {
            message.Content = _securityService.Encrypt(message.Content);
            _messageRepository.Create(message);
        }
        public void SendMessage(string fromBossName, string toBossName, string content)
        {
            Message message = new Message()
            {
                FromBossId = _bossRepository.GetByFullname(fromBossName).Id,
                ToBossId = _bossRepository.GetByFullname(toBossName).Id,
                Content = _securityService.Encrypt(content)
            };
            _messageRepository.Create(message);
        }
    }
}
