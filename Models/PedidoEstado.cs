using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class PedidoEstado
    {
        public PedidoEstado()
        {
            PedidoInformacions = new HashSet<PedidoInformacion>();
            PedidoProductos = new HashSet<PedidoProducto>();
        }

        public int EstId { get; set; }
        public string? EstNombre { get; set; }
        public string? EstDescripcion { get; set; }
        public bool? EstEstado { get; set; }

        public virtual ICollection<PedidoInformacion> PedidoInformacions { get; set; }
        public virtual ICollection<PedidoProducto> PedidoProductos { get; set; }
    }
}
