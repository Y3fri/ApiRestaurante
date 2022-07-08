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
    public class MenuDescuentoController : ControllerBase
    {
        private readonly IDescuentoService _descuentoService;

        public MenuDescuentoController(IDescuentoService descuentoService)
        {
            _descuentoService = descuentoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _descuentoService.get();
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]

        public IActionResult Add(MenuDescuentoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    MenuDescuento oDes = new MenuDescuento();
                    oDes.DesProducto = oModel.DesProducto;
                    oDes.DesPorcentaje = oModel.DesPorcentaje;
                    oDes.DesFechaInicio = oModel.DesFechaInicio;
                    oDes.DesFechaFinal = oModel.DesFechaFinal;
                    oDes.DesEstado = oModel.DesEstado;

                    db.MenuDescuentos.Add(oDes);
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
        public IActionResult Edit(MenuDescuentoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    MenuDescuento oDes = db.MenuDescuentos.Find(oModel.DesId);
                    oDes.DesProducto = oModel.DesProducto;
                    oDes.DesPorcentaje = oModel.DesPorcentaje;
                    oDes.DesFechaInicio = oModel.DesFechaInicio;
                    oDes.DesFechaFinal = oModel.DesFechaFinal;
                    oDes.DesEstado = oModel.DesEstado;

                    db.Entry(oDes).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    MenuDescuento oDes = db.MenuDescuentos.Find(Id);
                    db.Remove(oDes);
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
