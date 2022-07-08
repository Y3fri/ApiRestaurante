using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models.Services
{
    public class MunicipioService : IMunicipioService
    {
        private readonly RestauranteBDContext _context;

        public MunicipioService(RestauranteBDContext context)
        {
            _context = context;
        }
        public IQueryable<MaestroMunicipio> get()
        {
            return _context.MaestroMunicipios.Include(c => c.MunDepartamentoNavigation).OrderByDescending(a => a.MunId);
        }
    }
}
