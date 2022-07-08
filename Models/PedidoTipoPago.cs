using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class PedidoTipoPago
    {
        public PedidoTipoPago()
        {
            PedidoInformacions = new HashSet<PedidoInformacion>();
        }

        public int TipaId { get; set; }
        public string? TipaNombre { get; set; }
        public string? TipaDescripcion { get; set; }
        public bool? TipaEstado { get; set; }

        public virtual ICollection<PedidoInformacion> PedidoInformacions { get; set; }
    }
}
