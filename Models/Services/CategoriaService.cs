using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly RestauranteBDContext _context;

        public CategoriaService(RestauranteBDContext context)
        {
            _context = context;
        }
        public IQueryable<MenuCategorium> get()
        {
            return _context.MenuCategoria.Include(c => c.CarSedeNavigation).OrderByDescending(a => a.CatId);
        }
    }
}
