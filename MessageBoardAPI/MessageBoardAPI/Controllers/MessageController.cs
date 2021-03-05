// <copyright file="MessageController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MessageBoardAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MessageBoardAPI.DataContracts;
    using MessageBoardAPI.Models;
    using MessageBoardAPI.Services.IServices;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The Message Controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService messageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageController"/> class.
        /// </summary>
        /// <param name="messageService">The message service.</param>
        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        // GET: api/<MessagesController>

        /// <summary>
        /// Gets all messages.
        /// </summary>
        /// <returns>Gets all the user messages.</returns>
        [HttpGet]
        public async Task<IEnumerable<Message>> GetAllMessages()
        {
            var messages = await this.messageService.GetAllMessagesAsync();
            return messages;
        }

        // GET: api/<MessagesController>/username

        /// <summary>
        /// Gets the user messages.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>Get User Messages from username.</returns>
        [HttpGet("{username}")]
        public async Task<IEnumerable<Message>> GetUserMessages(string username)
        {
            var messages = await this.messageService.GetUserMessagesAsync(username);
            return messages;
        }

        // POST: api/<MessagesController>/username

        /// <summary>
        /// Creates the user messages.
        /// </summary>
        /// <param name="newMessage">The new message.</param>
        /// <returns>Create a new User Messages.</returns>
        [HttpPost]
        public async Task<ActionResult<Message>> CreateUserMessages(CreateMessage newMessage)
        {
            Message message = new Message()
            {
                MessageId = Guid.NewGuid(),
                Name = newMessage.Name,
                MessageText = newMessage.MessageText,
                CreatedDate = DateTime.Now,
            };

            await this.messageService.CreateUserMessagesAsync(message);

            return message;
        }
    }
}
