using MafiaAPI.Models;
using MafiaAPI.Repositories;
using MafiaAPI.Services;
using MafiaAPI.Services.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly IMessageRepository _messageRepository;
        private readonly ISecurityService _securityService;

        public MessageController(IMessageRepository messageRepository, ISecurityService securityService)
        {
            _messageRepository = messageRepository;
            _securityService = securityService;
        }

        [Route("/messageTo/{id}")]
        [HttpGet("{id}")]
        public JsonResult GetAllMessagesTo(long id)
        {
            var messages = _messageRepository
                .GetAllMessagesTo(id)
                .Select(x => new
                {
                    x.Id,
                    FromBoss = x.FromBoss.FirstName + " " + x.FromBoss.LastName,
                    ToBoss = x.ToBoss.FirstName + " " + x.ToBoss.LastName,
                    Content = _securityService.Decrypt(x.Content),
                    ReceiveDate = x.ReceiveDate
                }
                );
            return new JsonResult(messages);
        }

        [Route("/messageFrom/{id}")]
        [HttpGet("{id}")]
        public JsonResult GetAllMessagesFrom(long id)
        {
            var messages = _messageRepository
                .GetAllMessagesFrom(id)
                .Select(x => new
                {
                    x.Id,
                    FromBoss = x.FromBoss.FirstName + " " + x.FromBoss.LastName,
                    ToBoss = x.ToBoss.FirstName + " " + x.ToBoss.LastName,
                    Content = _securityService.Decrypt(x.Content),
                    ReceiveDate = x.ReceiveDate
                }
                );
            return new JsonResult(messages);
        }

        [HttpPost]
        public JsonResult SendMessage(Message message)
        {
            message.Content = _securityService.Encrypt(message.Content);
            message.ReceiveDate = DateTime.Now;
            _messageRepository.Create(message);
            return new JsonResult("Added successfully");
        }

        [Route("[controller]/id")]
        [HttpDelete("{id}")]
        public JsonResult DeleteMessage(int id)
        {
            _messageRepository.DeleteById(id);
            return new JsonResult("Deleted successfully");
        }
    }
}
