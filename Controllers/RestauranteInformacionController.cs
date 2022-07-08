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
    public class RestauranteInformacionController : ControllerBase
    {
        private readonly IRInfService _rinfService;

        public RestauranteInformacionController(IRInfService rinfService)
        {
            _rinfService = rinfService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    oRespuesta.Data = _rinfService.get();
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

        public IActionResult Add(RestauranteInfoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    RestauranteInformacion oRestaurante = new RestauranteInformacion();
                    oRestaurante.InfMunicipio = oModel.InfMunicipio;
                    oRestaurante.IntNit = oModel.IntNit;
                    oRestaurante.InfRazonSocial = oModel.InfRazonSocial;
                    oRestaurante.InfEmailPrincipal = oModel.InfEmailPrincipal;
                    oRestaurante.InfDireccionPrincipal = oModel.InfDireccionPrincipal;
                    oRestaurante.InfTelefonoPrincipal = oModel.InfTelefonoPrincipal;
                    oRestaurante.InfLogo = oModel.InfLogo;


                    db.RestauranteInformacions.Add(oRestaurante);
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
        public IActionResult Edit(RestauranteInfoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    RestauranteInformacion oRestaurante = db.RestauranteInformacions.Find(oModel.InfId);
                    oRestaurante.InfMunicipio = oModel.InfMunicipio;
                    oRestaurante.IntNit = oModel.IntNit;
                    oRestaurante.InfRazonSocial = oModel.InfRazonSocial;
                    oRestaurante.InfEmailPrincipal = oModel.InfEmailPrincipal;
                    oRestaurante.InfDireccionPrincipal = oModel.InfDireccionPrincipal;
                    oRestaurante.InfTelefonoPrincipal = oModel.InfTelefonoPrincipal;
                    oRestaurante.InfLogo = oModel.InfLogo;


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
                    RestauranteInformacion oRestaurante = db.RestauranteInformacions.Find(Id);
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
