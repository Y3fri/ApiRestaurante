using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    public partial class MenuAcompaniamiento
    {
        public int AcoId { get; set; }
        public string? AcoNombre { get; set; }
        public decimal? AcaPrecio { get; set; }
    }
}
