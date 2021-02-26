using MessageBoardAPI.Models;
using MessageBoardAPI.Services.IServices;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardAPI.Repositories
{
    public class MessageRepo : IMessageService
    {
        private readonly IMongoCollection<Message> messageCollection;
        private const string databaseName = "MessageBoardDev";
        private const string collectionName = "Messages";

        public MessageRepo(IMongoClient mongoClient)
        {
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(databaseName);
            messageCollection = mongoDatabase.GetCollection<Message>(collectionName);
        }

        public void CreateUserMessages(Message newMessage)
        {
            messageCollection.InsertOne(newMessage);
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return messageCollection.Find(new BsonDocument()).ToList();
        }

        public IEnumerable<Message> GetUserMessages(string username)
        {
            throw new NotImplementedException();
        }

        
    }
}
