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
    public class RestauranteSedeController : ControllerBase
    {
        private readonly IRSedeService _rsedeService;

        public RestauranteSedeController(IRSedeService rsedeService)
        {
            _rsedeService = rsedeService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    oRespuesta.Data = _rsedeService.get();
                    oRespuesta.Exito = 1;
                     
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]

        public IActionResult Add(RestauranteSedeRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    RestauranteSede oRestaurante = new RestauranteSede();
                    oRestaurante.SedInfirmation= oModel.SedInfirmation;
                    oRestaurante.SedEmail = oModel.SedEmail;
                    oRestaurante.SedInfDireccion = oModel.SedInfDireccion;
                    oRestaurante.SedInfTelefono = oModel.SedInfTelefono;
                    oRestaurante.SedUbicacionGoogle = oModel.SedUbicacionGoogle;
       

                    db.RestauranteSedes.Add(oRestaurante);
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
        public IActionResult Edit(RestauranteSedeRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    RestauranteSede oRestaurante = db.RestauranteSedes.Find(oModel.SedId);
                    oRestaurante.SedInfirmation = oModel.SedInfirmation;
                    oRestaurante.SedEmail = oModel.SedEmail;
                    oRestaurante.SedInfDireccion = oModel.SedInfDireccion;
                    oRestaurante.SedInfTelefono = oModel.SedInfTelefono;
                    oRestaurante.SedUbicacionGoogle = oModel.SedUbicacionGoogle;
                    db.Entry(oRestaurante).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    RestauranteSede oRestaurante = db.RestauranteSedes.Find(Id);
                    db.Remove(oRestaurante);
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
