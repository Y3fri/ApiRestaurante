namespace Restaurant.Models.Request
{
    public class MenuDescuentoRequest
    {
        public int DesId { get; set; }
        public int? DesProducto { get; set; }
        public decimal? DesPorcentaje { get; set; }
        public DateTime? DesFechaInicio { get; set; }
        public DateTime? DesFechaFinal { get; set; }
        public bool? DesEstado { get; set; }

    }
}
