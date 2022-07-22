using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class RestauranteInformacion
    {
        public RestauranteInformacion()
        {
            Colors = new HashSet<Color>();
            RestauranteSedes = new HashSet<RestauranteSede>();
            SsoUsuarios = new HashSet<SsoUsuario>();
        }

        public int InfId { get; set; }
        public int? InfMunicipio { get; set; }
        public string? IntNit { get; set; }
        public string? InfRazonSocial { get; set; }
        public string? InfEmailPrincipal { get; set; }
        public string? InfDireccionPrincipal { get; set; }
        public string? InfTelefonoPrincipal { get; set; }
        public string? InfLogo { get; set; }

        public virtual MaestroMunicipio? InfMunicipioNavigation { get; set; }
        public virtual ICollection<Color> Colors { get; set; }
        public virtual ICollection<RestauranteSede> RestauranteSedes { get; set; }
        public virtual ICollection<SsoUsuario> SsoUsuarios { get; set; }
    }
}
