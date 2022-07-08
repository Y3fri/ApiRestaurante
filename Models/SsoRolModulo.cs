using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class SsoRolModulo
    {
        public int? RomoRol { get; set; }
        public int? RomoModulo { get; set; }

        public virtual SsoModulo? RomoModuloNavigation { get; set; }
        public virtual SsoRol? RomoRolNavigation { get; set; }
    }
}
