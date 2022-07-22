using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models.Services
{
    public class ColorService : IColorService
    {
        private readonly RestauranteBDContext _context;

        public ColorService(RestauranteBDContext context)
        {
            _context = context;
        }
        public IQueryable<Color> get()
        {
            return _context.Colors.Include(c => c.ColRestaruranteNavigation).OrderByDescending(a => a.ColId);
        }
    }
}
