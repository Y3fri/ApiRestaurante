using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class PedidoInformacion
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

        public virtual PedidoEstado? InfEstadoNavigation { get; set; }
        public virtual MaestroMunicipio? InfMunicipioNavigation { get; set; }
        public virtual PedidoTipo? InfTipoNavigation { get; set; }
        public virtual PedidoTipoPago? InfTipoPagoNavigation { get; set; }
    }
}
