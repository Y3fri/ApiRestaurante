namespace Restaurant.Models.Services
{
    public interface IDescuentoService
    {
        public IQueryable<MenuDescuento> get();
    }
}
