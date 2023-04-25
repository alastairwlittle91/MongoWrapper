using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoWrapper.Models;

public class BaseEntity
{
    [BsonId]
    [JsonConverter(typeof(ObjectIdConverter))]
    public Guid Id { get; set; }
}

