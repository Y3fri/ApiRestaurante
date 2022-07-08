using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class PedidoProducto
    {
        public int ProId { get; set; }
        public int? ProProducto { get; set; }
        public int? ProEstado { get; set; }
        public string? ProSolicitudAdicional { get; set; }

        public virtual PedidoEstado? ProEstadoNavigation { get; set; }
        public virtual MenuProducto? ProProductoNavigation { get; set; }
    }
}
