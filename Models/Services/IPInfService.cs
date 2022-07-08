namespace Restaurant.Models.Services
{
    public interface IPInfService
    {
        public IQueryable<PedidoInformacion> get();
    }
}
