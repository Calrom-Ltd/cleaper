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
            new Message { Id = 10001, Name = "User 1", MessageText = "Test Message 1", CreatedDate = DateTime.Now},
            new Message { Id = 10002, Name = "User 1", MessageText = "Test Message 2", CreatedDate = DateTime.Now},
            new Message { Id = 20001, Name = "User 2", MessageText = "Test Message 3", CreatedDate = DateTime.Now}
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
    }
}
