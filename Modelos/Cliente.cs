using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBConsoleApp
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonElement("email")]
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}\nNombre: {this.Nombre}\nEmail: {this.Email}";
        }
    }
}
