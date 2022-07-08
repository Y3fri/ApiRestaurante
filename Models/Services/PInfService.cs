using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models.Services
{
    public class PInfService : IPInfService
    {
        private readonly RestauranteBDContext _context;

        public PInfService(RestauranteBDContext context)
        {
            _context = context;
        }
        public IQueryable<PedidoInformacion> get()
        {
            return _context.PedidoInformacions.Include(c => c.InfTipoNavigation)
                                              .Include(c => c.InfMunicipioNavigation)
                                              .Include(c => c.InfTipoPagoNavigation)
                                              .Include(c => c.InfEstadoNavigation)
                                              .OrderByDescending(a => a.InfId);
                    
        }
    }
}
