using BibliotecaClases.Models;
using BibliotecaClases.Repos;
using BibliotecaClases.Repositories;
using System;

namespace Parcial3App
{
    class Program
    {
        static void Main(string[] args)
        {
            ClienteRepositorio clienteRepo = new ClienteRepositorio();
            ProductoRepositorio productoRepo = new ProductoRepositorio();
            VentaRepositorio ventaRepo = new VentaRepositorio();

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== MENU PRINCIPAL ===");
                Console.WriteLine("1 - Registrar cliente");
                Console.WriteLine("2 - Registrar producto");
                Console.WriteLine("3 - Registrar venta");
                Console.WriteLine("4 - Ver ventas por cliente");
                Console.WriteLine("0 - Salir");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarCliente(clienteRepo);
                        break;

                    case "2":
                        RegistrarProducto(productoRepo);
                        break;

                    case "3":
                        RegistrarVenta(clienteRepo, productoRepo, ventaRepo);
                        break;

                    case "4":
                        VerVentasPorCliente(ventaRepo);
                        break;

                    case "0":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void RegistrarCliente(ClienteRepositorio clienteRepo)
        {
            Console.Clear();
            Console.WriteLine("=== NUEVO CLIENTE ===");
            Console.Write("Nombre y Apellido: ");
            string nombre = Console.ReadLine();
            Console.Write("Correo electronico: ");
            string correo = Console.ReadLine();

            Cliente c = new Cliente { Nombre = nombre, Correo = correo };
            clienteRepo.AgregarCliente(c);

            Console.WriteLine("Cliente agregado correctamente!");
            Console.ReadKey();
        }

        static void RegistrarProducto(ProductoRepositorio productoRepo)
        {
            Console.Clear();
            Console.WriteLine("=== NUEVO PRODUCTO ===");
            Console.Write("Producto: ");
            string nombre = Console.ReadLine();
            Console.Write("Precio:$ ");
            double precio = double.Parse(Console.ReadLine());

            Producto p = new Producto { Nombre = nombre, Precio = precio };
            productoRepo.AgregarProducto(p);

            Console.WriteLine("Producto registrado correctamente!");
            Console.ReadKey();
        }

        static void RegistrarVenta(ClienteRepositorio clienteRepo, ProductoRepositorio productoRepo, VentaRepositorio ventaRepo)
        {
            Console.Clear();
            Console.WriteLine("=== NUEVA VENTA ===");
            Console.Write("ID Cliente: ");
            int idCliente = int.Parse(Console.ReadLine());
            Console.Write("ID Producto: ");
            int idProducto = int.Parse(Console.ReadLine());
            Console.Write("Cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());

            var producto = productoRepo.ObtenerProductoPorId(idProducto);
            if (producto == null)
            {
                Console.WriteLine("Producto no encontrado");
                Console.ReadKey();
                return;
            }

            double subtotal = producto.Precio * cantidad;

            Venta v = new Venta
            {
                ClienteId = idCliente,
                Fecha = DateTime.Now
            };

            ventaRepo.RegistrarVenta(v, idProducto, cantidad, subtotal);

            Console.WriteLine("Venta registrada correctamente!");
            Console.ReadKey();
        }

        static void VerVentasPorCliente(VentaRepositorio ventaRepo)
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRO DE VENTAS POR CLIENTE ===");
            Console.Write("Ingrese ID del cliente: ");
            int idCliente = int.Parse(Console.ReadLine());

            var ventas = ventaRepo.ObtenerVentasPorCliente(idCliente);

            if (ventas.Count == 0)
            {
                Console.WriteLine("No hay ventas registradas para este cliente.");
            }
            else
            {
                foreach (var venta in ventas)
                {
                    Console.WriteLine($"Venta {venta.VentaId} - Fecha: {venta.Fecha}");
                }
            }

            Console.ReadKey();
        }
    }
}
