// <copyright file="MessageService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MessageBoardAPI.Services
{
    using System;
    using System.Collections.Generic;
    using MessageBoardAPI.Models;
    using MessageBoardAPI.Services.IServices;

    /// <summary>
    /// The Message Service.
    /// </summary>
    /// <seealso cref="MessageBoardAPI.Services.IServices.IMessageService" />
    public class MessageService : IMessageService
    {
        private readonly List<Message> messages = new List<Message>()
        {
            new Message { MessageId = Guid.NewGuid(), Name = "User 1", MessageText = "Test Message 1", CreatedDate = DateTime.Now },
            new Message { MessageId = Guid.NewGuid(), Name = "User 1", MessageText = "Test Message 2", CreatedDate = DateTime.Now },
            new Message { MessageId = Guid.NewGuid(), Name = "User 2", MessageText = "Test Message 3", CreatedDate = DateTime.Now },
        };

        /// <summary>
        /// Gets all messages.
        /// </summary>
        /// <returns>
        /// Gets all user messages.
        /// </returns>
        public IEnumerable<Message> GetAllMessages()
        {
            return this.messages;
        }

        /// <summary>
        /// Gets the user messages.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>
        /// Gets a specific users messages.
        /// </returns>
        public IEnumerable<Message> GetUserMessages(string username)
        {
            List<Message> userMessages = new List<Message>();
            foreach (var item in this.messages)
            {
                if (item.Name.Contains(username))
                {
                    userMessages.Add(item);
                }
            }

            return userMessages;
        }

        /// <summary>
        /// Creates the user messages.
        /// </summary>
        /// <param name="newMessage">The new message.</param>
        public void CreateUserMessages(Message newMessage)
        {
            this.messages.Add(newMessage);
        }
    }
}
