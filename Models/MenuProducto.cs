using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class MenuProducto
    {
        public MenuProducto()
        {
            MenuDescuentos = new HashSet<MenuDescuento>();
            PedidoProductos = new HashSet<PedidoProducto>();
        }

        public int ProId { get; set; }
        public int? ProCategoria { get; set; }
        public int? ProSede { get; set; }
        public string? ProNombre { get; set; }
        public string? ProDescripcion { get; set; }
        public decimal? ProPrecio { get; set; }
        public string? ProFoto { get; set; }
        public string? ProVideo { get; set; }
        public int? ProTiempoPreparacion { get; set; }
        public bool? ProEstado { get; set; }

        public virtual MenuCategorium? ProCategoriaNavigation { get; set; }
        public virtual RestauranteSede? ProSedeNavigation { get; set; }
        public virtual ICollection<MenuDescuento> MenuDescuentos { get; set; }
        public virtual ICollection<PedidoProducto> PedidoProductos { get; set; }
    }
}
