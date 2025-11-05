using BibliotecaClases.Data;
using BibliotecaClases.Models;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaClases.Repositories
{
    public class VentaRepositorio
    {
        private readonly AplicationDbContext _context;

        public VentaRepositorio()
        {
            _context = new AplicationDbContext();
        }

        public void RegistrarVenta(Venta venta, int productoId, int cantidad, double subtotal)
        {
            _context.Ventas.Add(venta);
            _context.SaveChanges();

            DetalleVenta detalle = new DetalleVenta
            {
                VentaId = venta.VentaId,
                ProductoId = productoId,
                Cantidad = cantidad,
                Subtotal = subtotal
            };

            _context.DetallesVentas.Add(detalle);
            _context.SaveChanges();
        }

        public List<Venta> ObtenerVentasPorCliente(int clienteId)
        {
            return _context.Ventas
                .Where(v => v.ClienteId == clienteId)
                .ToList();
        }
    }
}
