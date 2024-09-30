using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBConsoleApp
{
    public class Orden
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }
        
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("clienteId")]
        public string ClienteId { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonElement("producto")]
        public string Producto { get; set; }

        [BsonRepresentation(BsonType.Int32)]
        [BsonElement("cantidad")]
        public int Cantidad { get; set; }

        [BsonRepresentation(BsonType.Double)]
        [BsonElement("precio")]
        public double Precio { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}\nProducto:{this.Producto}\nCantidad:{this.Cantidad}\nPrecio:{this.Precio}";
        }
    }
}
