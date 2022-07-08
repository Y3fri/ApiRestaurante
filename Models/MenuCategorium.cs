using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class MenuCategorium
    {
        public MenuCategorium()
        {
            MenuProductos = new HashSet<MenuProducto>();
        }

        public int CatId { get; set; }
        public int? CarSede { get; set; }
        public string? CatNombre { get; set; }
        public string? CatDescripcion { get; set; }
        public bool? CatEstado { get; set; }

        public virtual RestauranteSede? CarSedeNavigation { get; set; }
        public virtual ICollection<MenuProducto> MenuProductos { get; set; }
    }
}
