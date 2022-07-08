using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class MaestroDepartamento
    {
        public MaestroDepartamento()
        {
            MaestroMunicipios = new HashSet<MaestroMunicipio>();
        }

        public int DepId { get; set; }
        public int DepPais { get; set; }
        public string? DepCodigoDane { get; set; }
        public string? DepNombre { get; set; }

        public virtual MaestroPai DepPaisNavigation { get; set; } = null!;
        public virtual ICollection<MaestroMunicipio> MaestroMunicipios { get; set; }
    }
}
