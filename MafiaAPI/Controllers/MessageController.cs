using MafiaAPI.Models;
using MafiaAPI.Repositories;
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

        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }


        /// <summary>
        /// Get all message to player with specified id
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("messageTo/{id}")]
        public JsonResult GetAllMessagesTo(long id)
        {
            var messages = _messageRepository
                .GetAllMessagesTo(id)
                .Select(x => new
                {
                    x.Id,
                    FromBoss = x.FromBoss.FirstName + " " + x.FromBoss.LastName,
                    ToBoss = x.ToBoss.FirstName + " " + x.ToBoss.LastName,
                    x.Content
                }
                );
            return new JsonResult(messages);
        }

        /// <summary>
        /// Get all message sent by player with specific id
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("messageFrom/{id}")]
        public JsonResult GetAllMessagesFrom(long id)
        {
            var messages = _messageRepository.GetAllMessagesFrom(id);
            return new JsonResult(messages);
        }

        /// <summary>
        /// Send message to boss
        /// </summary>
        /// <param name="message"></param>
        [HttpPost]
        public JsonResult SendMessage(Message message)
        {
            _messageRepository.Create(message);
            return new JsonResult("Added successfully");
        }

        /// <summary>
        /// Delete message by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public JsonResult DeleteMessage(int id)
        {
            _messageRepository.DeleteById(id);
            return new JsonResult("Deleted successfully");
        }
    }
}
