using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models.Services
{
    public class PProductoService : IPProductoService
    {
        private readonly RestauranteBDContext _context;

        public PProductoService(RestauranteBDContext context)
        {
            _context = context;
        }
        public IQueryable<PedidoProducto> get()
        {
            return _context.PedidoProductos.Include(c => c.ProProductoNavigation)
                                           .Include(c => c.ProEstadoNavigation)
                                           .OrderByDescending(a => a.ProId);
        }
    }
}
