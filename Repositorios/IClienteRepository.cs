using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBConsoleApp.Repositorios
{
    public interface IClienteRepository
    {
        List<Cliente> ObtenerClientes();
        Cliente ObtenerClientePorId(string Id);
        void InsertarCliente(Cliente cliente);  
    }
}
