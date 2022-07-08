namespace Restaurant.Models.Request
{
    public class MenuCategoriaRequest
    {
  

        public int CatId { get; set; }
        public int? CarSede { get; set; }
        public string? CatNombre { get; set; }
        public string? CatDescripcion { get; set; }
        public bool? CatEstado { get; set; }

    }
}
