using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoDBConsoleApp.Repositorios
{
    public class OrdenRepository : IOrdenRepository
    {
        private readonly IMongoCollection<Orden> _ordenCollection;

        public OrdenRepository(IMongoDatabase database)
        {
            _ordenCollection = database.GetCollection<Orden>("ordenes");
        }

        public List<Orden> ObtenerOrdenes()
        { 
            return _ordenCollection.Find(_ => true).ToList();
        }

        public List<Orden> ObtenerOrdenesPorClienteId(string cliente)
        { 
            return _ordenCollection.Find(o => o.ClienteId == cliente).ToList();
        }

        public void InsertarOrden(Orden orden)
        {
            _ordenCollection.InsertOne(orden);
        }

    }
}
