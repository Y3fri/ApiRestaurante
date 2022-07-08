namespace Restaurant.Models.Services
{
    public interface IMProductoService
    {
        public IQueryable<MenuProducto> get();
    }
}
