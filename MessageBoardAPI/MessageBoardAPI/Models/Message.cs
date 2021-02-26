using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoardAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Message
    {
        public Guid MessageId { get; set; }

        public string Name { get; set; }

        public string MessageText { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
