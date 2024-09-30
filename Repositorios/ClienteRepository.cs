using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBConsoleApp.Repositorios
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMongoCollection<Cliente> _clienteCollection;
        public ClienteRepository(IMongoDatabase database)
        {
            _clienteCollection = database.GetCollection<Cliente>("clientes");
        }

        public List<Cliente> ObtenerClientes()
        { 
            return _clienteCollection.Find(_ => true).ToList();
        }

        public Cliente ObtenerClientePorId(string id)
        { 
            return _clienteCollection.Find(c => c.Id == id).FirstOrDefault();
        }

        public void InsertarCliente(Cliente cliente)
        {
            _clienteCollection.InsertOne(cliente);
        }

    }
}
