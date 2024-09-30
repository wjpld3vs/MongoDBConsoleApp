using MongoDBConsoleApp.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBConsoleApp.Servicios
{
    public class OrdenService: IOrdenService
    {
        private readonly IOrdenRepository _ordenRepository;

        public OrdenService(IOrdenRepository ordenRepository)
        {
            _ordenRepository = ordenRepository;
        }

        public List<Orden> ObtenerTodasLasOrdenes()
        {
            return _ordenRepository.ObtenerOrdenes();
        }

        public List<Orden> ObtenerOrdenesPorClienteId(string clienteId)
        {
            return _ordenRepository.ObtenerOrdenesPorClienteId(clienteId);
        }

        public void RegistrarOrden(Orden orden)
        {
            _ordenRepository.InsertarOrden(orden);
        }

    }
}
