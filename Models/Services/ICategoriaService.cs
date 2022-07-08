namespace Restaurant.Models.Services
{
    public interface ICategoriaService
    {
        public IQueryable<MenuCategorium> get();
    }
}
