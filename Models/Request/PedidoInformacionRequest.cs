namespace Restaurant.Models.Request
{
    public class PedidoInformacionRequest
    {
        public int InfId { get; set; }
        public int? InfTipo { get; set; }
        public int? InfMunicipio { get; set; }
        public int? InfTipoPago { get; set; }
        public int? InfEstado { get; set; }
        public string? InfNombreCliente { get; set; }
        public string? InfDireccion { get; set; }
        public string? InfTelefono { get; set; }
        public string? InfNumeroPiso { get; set; }
        public string? InfNumeroMesa { get; set; }

 
    }
}
