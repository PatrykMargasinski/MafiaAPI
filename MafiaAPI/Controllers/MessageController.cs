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
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [Route("/messageTo/{id}")]
        [HttpGet("{id}")]
        public JsonResult GetAllMessagesTo(long id)
        {
            var messages = _messageService.GetAllMessagesTo(id);
            return new JsonResult(messages);
        }

        [Route("/messageFrom/{id}")]
        [HttpGet("{id}")]
        public JsonResult GetAllMessagesFrom(long id)
        {
            var messages = _messageService.GetAllMessagesFrom(id);
            return new JsonResult(messages);
        }

        [HttpPost]
        public JsonResult SendMessage(Message message)
        {
            _messageService.SendMessage(message);
            return new JsonResult("Added successfully");
        }

        [Route("[controller]/id")]
        [HttpDelete("{id}")]
        public JsonResult DeleteMessage(int id)
        {
            _messageService.DeleteMessage(id);
            return new JsonResult("Deleted successfully");
        }
    }
}
