using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class MenuProductoModificacion
    {
        public int? PrmoProducto { get; set; }
        public int? PrmoModificacion { get; set; }

        public virtual MenuModificacion? PrmoModificacionNavigation { get; set; }
        public virtual MenuProducto? PrmoProductoNavigation { get; set; }
    }
}
