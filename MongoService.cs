using System;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MongoDBConsoleApp
{
    public class MongoService
    {
        private readonly IMongoDatabase _database;

        // constructor
        public MongoService() 
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("ordenes_clientes");
        }

        // obtener coleccion de cliente
        public IMongoCollection<Cliente> ObtenerColeccionCliente()
        {
            return _database.GetCollection<Cliente>("clientes");
        }

        // obtener coleccion de ordenes
        public IMongoCollection<Orden> ObtenerColeccionOrden()
        {
            return _database.GetCollection<Orden>("ordenes");
        }

        public void AgregarCliente(Cliente cliente)
        {
            var collection = ObtenerColeccionCliente();
            collection.InsertOne(cliente);
            Console.WriteLine(cliente);
        }

        public void AgregarOrden(Orden orden)
        { 
            var collection = ObtenerColeccionOrden();
            collection.InsertOne(orden);
            Console.WriteLine(orden);
        }

        public List<Cliente> ObtenerClientes()
        {
            var collection = ObtenerColeccionCliente();
            return collection.Find(_ => true).ToList();
        }

        public List<Orden> ObtenerOrdenes()
        { 
            var collection = ObtenerColeccionOrden();
            return collection.Find(_ => true).ToList();
        }

    }
}
