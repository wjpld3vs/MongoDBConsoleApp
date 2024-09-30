using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBConsoleApp.Servicios
{
    public interface IOrdenService
    {
        List<Orden> ObtenerTodasLasOrdenes();
        List<Orden> ObtenerOrdenesPorClienteId(string clienteId);
        void RegistrarOrden(Orden orden);
    }
}
