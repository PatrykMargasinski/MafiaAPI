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

        /// <summary>
        /// Get all message to player with specified id
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("to/{id}")]
        public JsonResult GetAllMessagesTo(long bossId, int? fromRange, int? toRange, string bossNameFilter = "", bool onlyUnseen = false)
        {
            if (!fromRange.HasValue || !toRange.HasValue)
            {
                fromRange = 0; toRange = 5;
            }

            var messages = _messageRepository
                .GetAllMessagesTo(bossId, fromRange.Value, toRange.Value, bossNameFilter, onlyUnseen)
                .Select(x => new
                {
                    x.Id,
                    FromBoss = x.FromBoss.FirstName + " " + x.FromBoss.LastName,
                    ToBoss = x.ToBoss.FirstName + " " + x.ToBoss.LastName,
                    Subject = _securityService.Decrypt(x.Subject),
                    ReceivedDate = x.ReceivedDate,
                    Seen = x.Seen
                }
                );
            return new JsonResult(messages);
        }

        /// <summary>
        /// Get number of messages
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("count")]
        public JsonResult CountMessagesTo(long bossId)
        {
            var messageCount = _messageRepository.CountMessagesTo(bossId);
            return new JsonResult(messageCount);
        }

        /// <summary>
        /// Send message to boss
        /// </summary>
        /// <param name="message"></param>
        [HttpPost]
        public JsonResult SendMessage(Message message)
        {
            message.Subject = _securityService.Encrypt(message.Subject);
            message.Content = _securityService.Encrypt(message.Content);
            message.ReceivedDate = DateTime.Now;
            _messageRepository.Create(message);
            return new JsonResult("Added successfully");
        }

        /// <summary>
        /// Get message content
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("content/{id}")]
        public JsonResult GetMessageContent(int id)
        {
            var message = _messageRepository.GetById(id);
            message.Seen = true;
            _messageRepository.Update(message);
            var content = _securityService.Decrypt(message.Subject) + "\n\n" +
                _securityService.Decrypt(message.Content);
            return new JsonResult(content);
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

        [Route("/messages")]
        [HttpDelete]
        public JsonResult DeleteMessages(string stringIds)
        {
            long[] ids = stringIds.Split('i').Select(x => long.Parse(x)).ToArray();
            _messageRepository.DeleteByIds(ids);
            return new JsonResult("Deleted successfully");
        }
    }
}
