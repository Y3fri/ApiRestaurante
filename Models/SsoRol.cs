using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class SsoRol
    {
        public SsoRol()
        {
            SsoUsuarios = new HashSet<SsoUsuario>();
        }

        public int RolId { get; set; }
        public string? RolNombre { get; set; }
        public string? RolDescripcion { get; set; }

        public virtual ICollection<SsoUsuario> SsoUsuarios { get; set; }
    }
}
