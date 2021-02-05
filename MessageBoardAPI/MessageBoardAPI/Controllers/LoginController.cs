using MessageBoardAPI.DataContracts;
using MessageBoardAPI.Models;
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
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        //[HttpGet]
        //public bool Login(string username, string password)
        //{
        //    var messages = loginService.Login(username, password);
        //    return messages;
        //}

        // POST api/<LoginController>
        [HttpPost]
        public bool Login([FromBody] Login login)
        {
            var status = loginService.Login(login.UserName, login.Password);
            return status;
        }
    }
}
