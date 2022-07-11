using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Request;
using Restaurant.Models.Response;
using Restaurant.Services;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SsoUsuarioController : ControllerBase
    {
        private ISsoUsuarioService _ssoUsuarioService;

        public SsoUsuarioController(ISsoUsuarioService ssoUsuarioService)
        {
            _ssoUsuarioService = ssoUsuarioService;
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] SsoUsuarioRequest model)
        {
            Respuesta respuesta = new Respuesta();
            var userresponse = _ssoUsuarioService.Auth(model);

            if (userresponse == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Usuario o contraseña incorrecta";
                return BadRequest(respuesta);
            }
            respuesta.Exito = 1;
            respuesta.Data = userresponse;
            return Ok(respuesta);
        }
    }
}
