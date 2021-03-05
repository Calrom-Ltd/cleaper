// <copyright file="UserRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MessageBoardAPI.Repositories
{
    using MessageBoardAPI.Models;
    using MessageBoardAPI.Services.IServices;
    using MongoDB.Driver;

    /// <summary>
    /// The User Repo.
    /// </summary>
    /// <seealso cref="MessageBoardAPI.Services.IServices.ILoginService" />
    public class UserRepo : ILoginService
    {
        private const string DatabaseName = "MessageBoardDev";
        private const string CollectionName = "Users";
        private readonly IMongoCollection<User> userCollection;
        private readonly FilterDefinitionBuilder<User> filterBuilder = Builders<User>.Filter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepo"/> class.
        /// </summary>
        /// <param name="mongoClient">The mongo client.</param>
        public UserRepo(IMongoClient mongoClient)
        {
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            this.userCollection = mongoDatabase.GetCollection<User>(CollectionName);
        }

        /// <summary>
        /// Logins the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>A boolean for login.</returns>
        public bool Login(string username, string password)
        {
            var filter = this.filterBuilder.Where(user => user.UserName.Equals(username) && user.Password.Equals(password));
            if (this.userCollection.CountDocuments(filter).Equals(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
