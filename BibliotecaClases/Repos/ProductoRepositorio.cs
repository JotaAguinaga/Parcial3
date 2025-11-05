using BibliotecaClases.Data;
using BibliotecaClases.Models;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaClases.Repositories
{
    public class ProductoRepositorio
    {
        private readonly AplicationDbContext _context;

        public ProductoRepositorio()
        {
            _context = new AplicationDbContext();
        }

        public void AgregarProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
        }

        public Producto ObtenerProductoPorId(int id)
        {
            return _context.Productos.FirstOrDefault(p => p.ProductoId == id);
        }

        public List<Producto> ObtenerTodos()
        {
            return _context.Productos.ToList();
        }
    }
}
