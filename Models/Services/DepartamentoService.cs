using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly RestauranteBDContext _context;

        public DepartamentoService(RestauranteBDContext context)
        {
            _context = context;
        }
        public IQueryable<MaestroDepartamento> get()
        {
            return _context.MaestroDepartamentos.Include(c => c.DepPaisNavigation).OrderByDescending(a => a.DepId);
        }
    }
}
