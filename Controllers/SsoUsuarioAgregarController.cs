using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Request;
using Restaurant.Models.Response;
using Restaurant.Models.Services;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SsoUsuarioAgregarController : ControllerBase
    {
        private readonly ISsoUsuarioAgregarService _ssoUsuarioAgregarService;

        public SsoUsuarioAgregarController(ISsoUsuarioAgregarService ssoUsuarioAgregarService)
        {
            _ssoUsuarioAgregarService = ssoUsuarioAgregarService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                oRespuesta.Data = _ssoUsuarioAgregarService.get();
                    oRespuesta.Exito = 1;    
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]

        public IActionResult Add(SsoUsuarioAgregarRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    SsoUsuario oUsu = new SsoUsuario();
                    oUsu.UsuRol = oModel.UsuRol;
                    oUsu.UsuRestaurante = oModel.UsuRestaurante;
                    oUsu.UsuDocumento= oModel.UsuDocumento;
                    oUsu.UsuNombre= oModel.UsuNombre;
                    oUsu.UsuApellido= oModel.UsuApellido;
                    oUsu.UsuNickname= oModel.UsuNickname;
                    oUsu.UsuContrasenia= oModel.UsuContrasenia;
                    db.SsoUsuarios.Add(oUsu);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(SsoUsuarioAgregarRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    SsoUsuario oUsu = db.SsoUsuarios.Find(oModel.UsuId);
                    oUsu.UsuRol = oModel.UsuRol;
                    oUsu.UsuRestaurante = oModel.UsuRestaurante;
                    oUsu.UsuDocumento = oModel.UsuDocumento;
                    oUsu.UsuNombre = oModel.UsuNombre;
                    oUsu.UsuApellido = oModel.UsuApellido;
                    oUsu.UsuNickname = oModel.UsuNickname;
                    oUsu.UsuContrasenia = oModel.UsuContrasenia;

                    db.Entry(oUsu).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }



        [HttpDelete("{Id}")]

        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    SsoUsuario oUsu = db.SsoUsuarios.Find(Id);
                    db.Remove(oUsu);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
