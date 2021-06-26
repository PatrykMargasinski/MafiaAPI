using MafiaAPI.Models;
using MafiaAPI.Repositories;
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
        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [Route("/messageTo/{id}")]
        [HttpGet("{id}")]
        public JsonResult GetAllMessagesTo(int id)
        {
            var messages = _messageRepository
                .GetAllMessageTo(id)
                .Select(x => new
                {
                    x.MessageId,
                    FromBoss = x.FromBoss.FirstName + " " + x.FromBoss.LastName,
                    ToBoss = x.ToBoss.FirstName + " " + x.ToBoss.LastName,
                    x.Content
                }
                );
            return new JsonResult(messages);
        }

        [Route("/messageFrom/{id}")]
        [HttpGet("{id}")]
        public JsonResult GetAllMessagesFrom(int id)
        {
            var messages = _messageRepository.GetAllMessageFrom(id);
            return new JsonResult(messages);
        }

        [HttpPost]
        public JsonResult SendMessage(Message message)
        {
            _messageRepository.Post(message);
            return new JsonResult("Added successfully");
        }

        [Route("[controller]/id")]
        [HttpDelete("{id}")]
        public JsonResult DeleteMessage(int id)
        {
            _messageRepository.Delete(id);
            return new JsonResult("Deleted successfully");
        }
    }
}
