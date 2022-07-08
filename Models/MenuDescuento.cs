using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class MenuDescuento
    {
        public int DesId { get; set; }
        public int? DesProducto { get; set; }
        public decimal? DesPorcentaje { get; set; }
        public DateTime? DesFechaInicio { get; set; }
        public DateTime? DesFechaFinal { get; set; }
        public bool? DesEstado { get; set; }

        public virtual MenuProducto? DesProductoNavigation { get; set; }
    }
}
