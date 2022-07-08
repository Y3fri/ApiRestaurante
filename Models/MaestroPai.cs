using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class MaestroPai
    {
        public MaestroPai()
        {
            MaestroDepartamentos = new HashSet<MaestroDepartamento>();
        }

        public int PaiId { get; set; }
        public string? PaiNombre { get; set; }

        public virtual ICollection<MaestroDepartamento> MaestroDepartamentos { get; set; }
    }
}
