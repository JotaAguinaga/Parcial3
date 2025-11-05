using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaClases.Data;
using BibliotecaClases.Models;

namespace BibliotecaClases.Repos
{
       public class ClienteRepositorio
        {
            private readonly AplicationDbContext _context;

            public ClienteRepositorio()
            {
                _context = new AplicationDbContext();
            }

        public void AgregarCliente(Cliente cliente)
        {
            // Verificar si ya existe un cliente con el mismo email
            var clienteExistente = _context.Clientes
                .FirstOrDefault(c => c.Correo == cliente.Correo);

            if (clienteExistente != null)
            {
                Console.WriteLine("Ya existe un cliente registrado con ese email.");
                return;
            }

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            Console.WriteLine("Cliente agregado correctamente.");
        }


        public Cliente ObtenerClientePorId(int id)
            {
                return _context.Clientes.FirstOrDefault(c => c.ClienteId == id);
            }

            public List<Cliente> ObtenerTodos()
            {
                return _context.Clientes.ToList();
            }
        }
    }
