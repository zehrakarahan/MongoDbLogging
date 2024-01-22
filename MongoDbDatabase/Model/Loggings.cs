using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbDatabase.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDatabase.Model
{
    public class Loggings
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("LoggingName")]
        public string LoggingName { get; set; } = null!;

        public Status Status { get; set; }

        public string LoggingDescription { get; set; } = null!;

        public string ControllerName { get; set; } = null!;

        public string ActionName { get; set; } = null!;

    }
}
