using MessageBoardAPI.Models;
using MessageBoardAPI.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardAPI.Services
{
    public class LoginService : ILoginService
    {
        private readonly List<User> users = new List<User>()
        {
            new User { UserName = "User1", Password = "Password1"},
            new User { UserName = "User2", Password = "Password2"},
            new User { UserName = "User3", Password = "Password3"}
        };

        public bool Login(string username, string password)
        {
            bool status = this.users.Any(x => x.UserName == username && x.Password == password);
            return status;
        }
    }
}
