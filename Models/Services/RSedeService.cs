using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models.Services
{
    public class RSedeService : IRSedeService
    {
        private readonly RestauranteBDContext _context;

        public RSedeService(RestauranteBDContext context)
        {
            _context = context;
        }
        public IQueryable<RestauranteSede> get()
        {
           return _context.RestauranteSedes.Include(c=>c.SedInfirmationNavigation).OrderByDescending(a=>a.SedId);
        }
    }
}
