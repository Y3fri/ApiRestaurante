using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models.Services
{
    public class DescuentoService : IDescuentoService
    {
        private readonly RestauranteBDContext _context;

        public DescuentoService(RestauranteBDContext context)
        {
            _context = context;
        }
        public IQueryable<MenuDescuento> get()
        {
            return _context.MenuDescuentos.Include(c => c.DesProductoNavigation).OrderByDescending(a => a.DesId);
        }
    }
}
