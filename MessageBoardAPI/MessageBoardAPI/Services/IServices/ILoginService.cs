using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardAPI.Services.IServices
{
    public interface ILoginService
    {
        public bool Login(string username, string password);
    }
}
