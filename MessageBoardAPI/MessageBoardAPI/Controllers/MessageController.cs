using MessageBoardAPI.DataContracts;
using MessageBoardAPI.Models;
using MessageBoardAPI.Services;
using MessageBoardAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MessageBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        // GET: api/<MessagesController>
        [HttpGet]
        public IEnumerable<Message> GetAllMessages()
        {
            var messages = messageService.GetAllMessages();
            return messages;
        }

        // GET: api/<MessagesController>/username
        [HttpGet("{username}")]
        public IEnumerable<Message> GetUserMessages(string username)
        {
            var messages = messageService.GetUserMessages(username);
            return messages;
        }

        [HttpPost]
        public ActionResult<Message> CreateUserMessages(CreateMessage newMessage)
        {
            Message message = new Message()
            {
                MessageId = Guid.NewGuid(),
                Name = newMessage.Name,
                MessageText = newMessage.MessageText,
                CreatedDate = DateTime.Now
            };

            messageService.CreateUserMessages(message);

            return message;
        }
    }
}
