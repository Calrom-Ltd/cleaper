// <copyright file="LoginController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MessageBoardAPI.Controllers
{
    using MessageBoardAPI.DataContracts;
    using MessageBoardAPI.Services.IServices;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The Login Controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        /// <param name="loginService">The login service.</param>
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        // POST api/<LoginController>

        /// <summary>
        /// Logins the specified login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>the login service.</returns>
        [HttpPost]
        public bool Login([FromBody] Login login)
        {
            var status = this.loginService.Login(login.UserName, login.Password);
            return status;
        }
    }
}
