// <copyright file="ILoginService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MessageBoardAPI.Services.IServices
{
    /// <summary>
    /// The Login Service Interface.
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Logins the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>A Login boolean.</returns>
        public bool Login(string username, string password);
    }
}
