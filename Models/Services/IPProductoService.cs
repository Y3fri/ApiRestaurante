namespace Restaurant.Models.Services
{
    public interface IPProductoService
    {
        public IQueryable<PedidoProducto> get();
    }
}
