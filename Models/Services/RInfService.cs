using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models.Services
{
    public class RInfService : IRInfService
    {
        private readonly RestauranteBDContext _context;

        public RInfService(RestauranteBDContext context)
        {
            _context = context;
        }
        public IQueryable<RestauranteInformacion> get()
        {
            return _context.RestauranteInformacions.Include(c => c.InfMunicipioNavigation).OrderByDescending(a => a.InfId);
        }
    }
}
