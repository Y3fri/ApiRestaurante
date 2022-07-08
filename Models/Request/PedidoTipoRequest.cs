namespace Restaurant.Models.Request
{
    public class PedidoTipoRequest
    { 

        public int TipId { get; set; }
        public string? TipNombre { get; set; }
        public string? TipDescripcion { get; set; }
        public bool? TipEstado { get; set; }

    }
}
