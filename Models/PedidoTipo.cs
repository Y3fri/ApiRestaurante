using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class PedidoTipo
    {
        public PedidoTipo()
        {
            PedidoInformacions = new HashSet<PedidoInformacion>();
        }

        public int TipId { get; set; }
        public string? TipNombre { get; set; }
        public string? TipDescripcion { get; set; }
        public bool? TipEstado { get; set; }

        public virtual ICollection<PedidoInformacion> PedidoInformacions { get; set; }
    }
}
