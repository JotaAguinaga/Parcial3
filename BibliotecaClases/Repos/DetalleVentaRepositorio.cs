using BibliotecaClases.Data;
using BibliotecaClases.Models;
using System.Collections.Generic;
using System.Linq;

namespace BBibliotecaClases.Repos
{
    public class DetalleVentaRepositorio
    {
        private readonly AplicationDbContext _context;

        public DetalleVentaRepositorio()
        {
            _context = new AplicationDbContext();
        }

        public void AgregarDetalle(DetalleVenta detalle)
        {
            _context.DetallesVentas.Add(detalle);
            _context.SaveChanges();
        }

        public List<DetalleVenta> ObtenerDetallesPorVenta(int ventaId)
        {
            return _context.DetallesVentas
                .Where(d => d.VentaId == ventaId)
                .ToList();
        }

        public List<DetalleVenta> ObtenerTodos()
        {
            return _context.DetallesVentas.ToList();
        }
    }
}
