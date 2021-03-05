// <copyright file="IMessageService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MessageBoardAPI.Services.IServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MessageBoardAPI.Models;

    /// <summary>
    /// The Message Service Interface.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Gets all messages.
        /// </summary>
        /// <returns>Gets all user messages.</returns>
        Task<IEnumerable<Message>> GetAllMessagesAsync();

        /// <summary>
        /// Gets the user messages.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>Gets a specific users messages.</returns>
        Task<IEnumerable<Message>> GetUserMessagesAsync(string username);

        /// <summary>
        /// Creates the user messages.
        /// </summary>
        /// <param name="newMessage">The new message.</param>
        Task CreateUserMessagesAsync(Message newMessage);
    }
}
