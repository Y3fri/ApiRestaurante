namespace Restaurant.Models.Request
{
    public class PedidoTipoPagoRequest
    {
      
        public int TipaId { get; set; }
        public string? TipaNombre { get; set; }
        public string? TipaDescripcion { get; set; }
        public bool? TipaEstado { get; set; }

    }
}
