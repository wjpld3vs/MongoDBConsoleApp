using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBConsoleApp.Repositorios
{
    public interface IOrdenRepository
    {
        List<Orden> ObtenerOrdenes();
        List<Orden> ObtenerOrdenesPorClienteId(string cliente);
        void InsertarOrden(Orden orden);
    }
}
