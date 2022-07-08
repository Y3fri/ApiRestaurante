using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class RestauranteSede
    {
        public RestauranteSede()
        {
            MenuCategoria = new HashSet<MenuCategorium>();
            MenuProductos = new HashSet<MenuProducto>();
        }

        public int SedId { get; set; }
        public int? SedInfirmation { get; set; }
        public string? SedEmail { get; set; }
        public string? SedInfDireccion { get; set; }
        public string? SedInfTelefono { get; set; }
        public string? SedUbicacionGoogle { get; set; }

        public virtual RestauranteInformacion? SedInfirmationNavigation { get; set; }
        public virtual ICollection<MenuCategorium> MenuCategoria { get; set; }
        public virtual ICollection<MenuProducto> MenuProductos { get; set; }
    }
}
