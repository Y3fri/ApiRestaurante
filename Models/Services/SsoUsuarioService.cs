using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Models;
using Restaurant.Models.Common;
using Restaurant.Models.Request;
using Restaurant.Models.Response;
using Restaurant.Tools;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



namespace Restaurant.Services
{
    public class SsoUsuarioService : ISsoUsuarioService
    {

        private readonly AppSettings _appSettings;

        public SsoUsuarioService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserResponse Auth(SsoUsuarioRequest model)
        {
            UserResponse userresponse = new UserResponse();
            using(var db= new RestauranteBDContext())
            {
                string spassword = Encrypt.GetSHA256(model.UsuContrasenia);
                var usuario =db.SsoUsuarios.Where(d=> d.UsuNickname == model.UsuNickname && 
                                              d.UsuContrasenia == spassword).FirstOrDefault();
                if (usuario == null) return null;

                userresponse.UsuNickname = usuario.UsuNickname;
                userresponse.Token = GetToken(usuario);
            }
            return userresponse;

        }

        private string GetToken(SsoUsuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier,usuario.UsuId.ToString()),
                         new Claim(ClaimTypes.Email,usuario.UsuNickname)
                    }
                    ),
                    Expires = DateTime.UtcNow.AddDays(60),
                    SigningCredentials=
                    new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
