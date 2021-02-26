using MessageBoardAPI.Models;
using MessageBoardAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardAPI.Services
{
    public class MessageService : IMessageService
    {
        private readonly List<Message> messages = new List<Message>()
        {
            new Message { MessageId = Guid.NewGuid(), Name = "User 1", MessageText = "Test Message 1", CreatedDate = DateTime.Now},
            new Message { MessageId = Guid.NewGuid(), Name = "User 1", MessageText = "Test Message 2", CreatedDate = DateTime.Now},
            new Message { MessageId = Guid.NewGuid(), Name = "User 2", MessageText = "Test Message 3", CreatedDate = DateTime.Now}
        };

        public IEnumerable<Message> GetAllMessages()
        {
            return messages;
        }

        public IEnumerable<Message> GetUserMessages(string username)
        {
            List<Message> userMessages = new List<Message>();
            foreach (var item in messages)
            {
                if (item.Name.Contains(username))
                {
                    userMessages.Add(item);
                }
            }
            return userMessages;
        }

        public void CreateUserMessages(Message newMessage)
        {
            messages.Add(newMessage);
        }
    }
}
