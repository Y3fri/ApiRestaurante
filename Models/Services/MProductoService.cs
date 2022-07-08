using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models.Services
{
    public class MProductoService : IMProductoService
    {
        private readonly RestauranteBDContext _context;

        public MProductoService(RestauranteBDContext context)
        {
            _context = context;
        }
        public IQueryable<MenuProducto> get()
        {
            return _context.MenuProductos.Include(c => c.ProCategoriaNavigation)
                                                  .Include(c=>c.ProSedeNavigation).OrderByDescending(a => a.ProId);
        }
    }
}
