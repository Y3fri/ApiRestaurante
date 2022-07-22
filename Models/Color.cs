using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class Color
    {
        public int ColId { get; set; }
        public int? ColRestarurante { get; set; }
        public string? ColFondo { get; set; }
        public string? ColEncabezado { get; set; }
        public string? ColFuente { get; set; }
        public string? ColTitulos { get; set; }
        public string? ColTitEncabezado { get; set; }
        public string? ColTituMenu { get; set; }
        public string? ColConteMenu { get; set; }

        public virtual RestauranteInformacion? ColRestaruranteNavigation { get; set; }
    }
}
