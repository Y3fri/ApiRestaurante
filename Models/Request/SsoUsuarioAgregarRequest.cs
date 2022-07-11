namespace Restaurant.Models.Request
{
    public class SsoUsuarioAgregarRequest
    {
        public int UsuId { get; set; }
        public int? UsuRestaurante { get; set; }
        public int? UsuRol { get; set; }
        public string? UsuDocumento { get; set; }
        public string? UsuNombre { get; set; }
        public string? UsuApellido { get; set; }
        public string UsuNickname { get; set; } = null!;
        public string UsuContrasenia { get; set; } = null!;
    }
}
