using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class PedidoAcompaniamineto
    {
        public int? AcoProducto { get; set; }
        public int? AcoAcompaniamiento { get; set; }
        public int? AcoCantidad { get; set; }

        public virtual MenuAcompaniamiento? AcoAcompaniamientoNavigation { get; set; }
        public virtual PedidoProducto? AcoProductoNavigation { get; set; }
    }
}
