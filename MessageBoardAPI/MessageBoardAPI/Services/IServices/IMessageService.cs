using MessageBoardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardAPI.Services.IServices
{
    public interface IMessageService
    {
        IEnumerable<Message> GetAllMessages();

        IEnumerable<Message> GetUserMessages(string username);
    }
}
