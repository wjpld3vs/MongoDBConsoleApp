using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBConsoleApp.Servicios
{
    public interface IClienteService
    {
        List<Cliente> ObtenerTodosLosClientes();
        Cliente ObtenerClientePorId(string id);

        void RegistrarCliente(Cliente cliente); 
    }
}
