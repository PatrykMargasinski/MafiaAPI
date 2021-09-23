using MafiaAPI.Models;
using MafiaAPI.Repositories;
using MafiaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Linq;

namespace MafiaAPI.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "Player")]
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

        [HttpGet("to")]
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

        [HttpGet("count")]
        public JsonResult CountMessagesTo(long bossId)
        {
            var messageCount = _messageRepository.CountMessagesTo(bossId);
            return new JsonResult(messageCount);
        }

        [HttpPost]
        public JsonResult SendMessage(Message message)
        {
            message.Subject = _securityService.Encrypt(message.Subject);
            message.Content = _securityService.Encrypt(message.Content);
            message.ReceivedDate = DateTime.Now;
            _messageRepository.Create(message);
            return new JsonResult("Added successfully");
        }

        [HttpGet("content")]
        public JsonResult GetMessageContent(int id)
        {
            var message = _messageRepository.GetById(id);
            message.Seen = true;
            _messageRepository.Update(message);
            var content = _securityService.Decrypt(message.Subject) + "\n\n" +
                _securityService.Decrypt(message.Content);
            return new JsonResult(content);
        }

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
