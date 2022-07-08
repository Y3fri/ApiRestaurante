using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models.Request
{
    public class SsoUsuarioRequest
    {
         [Required]
        public string UsuNickname { get; set; }

        [Required]
        public string UsuContrasenia { get; set; }
        
       

  
    }
}
