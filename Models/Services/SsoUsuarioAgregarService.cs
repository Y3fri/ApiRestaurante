using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models.Services
{
    public class SsoUsuarioAgregarService : ISsoUsuarioAgregarService
    {
        private readonly RestauranteBDContext _context;

        public SsoUsuarioAgregarService(RestauranteBDContext context)
        {
            _context = context;
        }
        public IQueryable<SsoUsuario> get()
        {
            return _context.SsoUsuarios.Include(c => c.UsuRolNavigation)
                .Include(c=>c.UsuRestauranteNavigation).OrderByDescending(a => a.UsuId);
        }
    }
}
