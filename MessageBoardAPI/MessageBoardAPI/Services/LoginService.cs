// <copyright file="LoginService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MessageBoardAPI.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using MessageBoardAPI.Models;
    using MessageBoardAPI.Services.IServices;

    /// <summary>
    /// The Login Service.
    /// </summary>
    /// <seealso cref="MessageBoardAPI.Services.IServices.ILoginService" />
    public class LoginService : ILoginService
    {
        /// <summary>
        /// The list of users local.
        /// </summary>
        private readonly List<User> users = new List<User>()
        {
            new User { UserName = "User 1", Password = "Password1" },
            new User { UserName = "User 2", Password = "Password2" },
            new User { UserName = "User 3", Password = "Password3" },
        };

        /// <summary>
        /// Logins the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// A Login boolean.
        /// </returns>
        public bool Login(string username, string password)
        {
            bool status = this.users.Any(x => x.UserName == username && x.Password == password);
            return status;
        }
    }
}
