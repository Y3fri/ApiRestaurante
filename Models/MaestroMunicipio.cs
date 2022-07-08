using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class MaestroMunicipio
    {
        public MaestroMunicipio()
        {
            PedidoInformacions = new HashSet<PedidoInformacion>();
            RestauranteInformacions = new HashSet<RestauranteInformacion>();
        }

        public int MunId { get; set; }
        public int MunDepartamento { get; set; }
        public string? MunCodigoDane { get; set; }
        public string? MunNombre { get; set; }

        public virtual MaestroDepartamento MunDepartamentoNavigation { get; set; } = null!;
        public virtual ICollection<PedidoInformacion> PedidoInformacions { get; set; }
        public virtual ICollection<RestauranteInformacion> RestauranteInformacions { get; set; }
    }
}
