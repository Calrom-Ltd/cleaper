// <copyright file="MessageRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MessageBoardAPI.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MessageBoardAPI.Models;
    using MessageBoardAPI.Services.IServices;
    using MongoDB.Bson;
    using MongoDB.Driver;

    /// <summary>
    /// The Message Repo.
    /// </summary>
    /// <seealso cref="MessageBoardAPI.Services.IServices.IMessageService" />
    public class MessageRepo : IMessageService
    {
        private const string DatabaseName = "MessageBoardDev";
        private const string CollectionName = "Messages";
        private readonly IMongoCollection<Message> messageCollection;
        private readonly FilterDefinitionBuilder<Message> filterBuilder = Builders<Message>.Filter;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageRepo"/> class.
        /// </summary>
        /// <param name="mongoClient">The mongo client.</param>
        public MessageRepo(IMongoClient mongoClient)
        {
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            this.messageCollection = mongoDatabase.GetCollection<Message>(CollectionName);
        }

        /// <summary>
        /// Creates the user messages.
        /// </summary>
        /// <param name="newMessage">The new message.</param>
        public async Task CreateUserMessagesAsync(Message newMessage)
        {
            await this.messageCollection.InsertOneAsync(newMessage);
        }

        /// <summary>
        /// Gets all messages.
        /// </summary>
        /// <returns>Gets all user messages.</returns>
        public async Task<IEnumerable<Message>> GetAllMessagesAsync()
        {
            return await this.messageCollection.Find(new BsonDocument()).ToListAsync();
        }

        /// <summary>
        /// Gets the user messages.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>Gets a users messages.</returns>
        public async Task<IEnumerable<Message>> GetUserMessagesAsync(string username)
        {
            var filter = this.filterBuilder.Eq(message => message.Name, username);
            return await this.messageCollection.Find(filter).ToListAsync();
        }
    }
}
