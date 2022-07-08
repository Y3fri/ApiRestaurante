namespace Restaurant.Models.Request
{
    public class PedidoEstadoRequest
    {
   

        public int EstId { get; set; }
        public string? EstNombre { get; set; }
        public string? EstDescripcion { get; set; }
        public bool? EstEstado { get; set; }

    }
}
