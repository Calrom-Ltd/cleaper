using MessageBoardAPI.Models;
using MessageBoardAPI.Services.IServices;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardAPI.Repositories
{
    public class UserRepo : ILoginService
    {
        private readonly IMongoCollection<User> userCollection;
        private const string databaseName = "MessageBoardDev";
        private const string collectionName = "Users";

        public UserRepo(IMongoClient mongoClient)
        {
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(databaseName);
            userCollection = mongoDatabase.GetCollection<User>(collectionName);
        }

        public bool Login(string username, string password)
        {
            //return userCollection.A({ username, password});
            return true;
        }
    }
}
