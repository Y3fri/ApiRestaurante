namespace Restaurant.Models.Request
{
    public class PedidoProductoRequest
    {
        public int ProId { get; set; }
        public int? ProProducto { get; set; }
        public int? ProEstado { get; set; }
        public string? ProSolicitudAdicional { get; set; }

    }
}
