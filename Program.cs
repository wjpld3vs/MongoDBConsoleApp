using System;
using MongoDB.Driver;
using MongoDBConsoleApp.Repositorios;
using MongoDBConsoleApp.Servicios;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;

namespace MongoDBConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "MONGO APP - mongo db";

            var randomGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
            var randomNumGen = RandomizerFactory.GetRandomizer(new FieldOptionsInteger { Min = 1, Max = 1000 });
            var randomNumDobuleGen = RandomizerFactory.GetRandomizer(new FieldOptionsDouble { Min = 1, Max = 1000 });
            string randomName = "";
            string randomLastname = "";
            string randomEmail = "";
            string randomProducto = "";
            int randomCantidad = 0;
            double randomPrecio = 0.0;

            // Crear la conexión a MongoDB
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("tienda");

            // Inyectar repositorios
            IClienteRepository clienteRepository = new ClienteRepository(database);
            IOrdenRepository ordenRepository = new OrdenRepository(database);

            // Inyectar servicios
            IClienteService clienteService = new ClienteService(clienteRepository);
            IOrdenService ordenService = new OrdenService(ordenRepository);


            for (int i = 0; i < 1000; i++)
            {
                randomGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
                randomName = randomGenerator.Generate();

                randomGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsLastName());
                randomLastname = randomGenerator.Generate();

                randomGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsEmailAddress());
                randomEmail = randomGenerator.Generate();

                randomGenerator = RandomizerFactory.GetRandomizer(new FieldOptionsText());
                randomProducto = randomGenerator.Generate();

                randomNumGen = RandomizerFactory.GetRandomizer(new FieldOptionsInteger { Min = 1, Max = 1000 });
                randomCantidad = randomNumGen.Generate().Value;

                randomNumDobuleGen = RandomizerFactory.GetRandomizer(new FieldOptionsDouble { Min = 1, Max = 1000 });
                randomPrecio = randomNumDobuleGen.Generate().Value;

                var cliente = new Cliente
                {
                    Nombre = randomName + " " + randomLastname,
                    Email = randomEmail
                };

                clienteService.RegistrarCliente(cliente);

                var orden = new Orden
                {
                    ClienteId = cliente.Id,
                    Producto = randomProducto,
                    Cantidad = randomCantidad,
                    Precio = randomPrecio
                };

                ordenService.RegistrarOrden(orden);
            }


            // consultar
            Console.WriteLine("\n\nClientes: ");
            var clientes = clienteService.ObtenerTodosLosClientes();
            foreach (var c in clientes)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine("\n\nOrdenes: ");
            var ordenes = ordenService.ObtenerTodasLasOrdenes();
            foreach (var o in ordenes)
            {
                Console.WriteLine(o);
            }

            Console.ReadKey();

        }
    }
}
