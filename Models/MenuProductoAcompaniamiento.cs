using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class MenuProductoAcompaniamiento
    {
        public int? PracProducto { get; set; }
        public int? PracAcompaniamiento { get; set; }

        public virtual MenuAcompaniamiento? PracAcompaniamientoNavigation { get; set; }
        public virtual MenuProducto? PracProductoNavigation { get; set; }
    }
}
