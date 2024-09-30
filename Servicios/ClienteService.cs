using MongoDBConsoleApp.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBConsoleApp.Servicios
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> ObtenerTodosLosClientes()
        {
            return _clienteRepository.ObtenerClientes();        
        }

        public Cliente ObtenerClientePorId(string id)
        {
            return _clienteRepository.ObtenerClientePorId(id);
        }

        public void RegistrarCliente(Cliente cliente)
        {
            _clienteRepository.InsertarCliente(cliente);
        }

    }
}
