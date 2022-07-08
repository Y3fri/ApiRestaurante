namespace Restaurant.Models.Request
{
    public class MenuProductoRequest
    {
   

        public int ProId { get; set; }
        public int? ProCategoria { get; set; }
        public int? ProSede { get; set; }
        public string? ProNombre { get; set; }
        public string? ProDescripcion { get; set; }
        public decimal? ProPrecio { get; set; }
        public string? ProFoto { get; set; }
        public string? ProVideo { get; set; }
        public int? ProTiempoPreparacion { get; set; }
        public bool? ProEstado { get; set; }

        
    }
}
