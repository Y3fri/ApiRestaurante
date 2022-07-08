using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class PedidoModificacion
    {
        public int? ModProducto { get; set; }
        public int? ModModificacion { get; set; }
        public int? AcoCantidad { get; set; }

        public virtual MenuModificacion? ModModificacionNavigation { get; set; }
        public virtual PedidoProducto? ModProductoNavigation { get; set; }
    }
}
