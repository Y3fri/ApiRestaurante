using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Request;
using Restaurant.Models.Response;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoTipoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    var lst = db.PedidoTipos.OrderByDescending(d => d.TipId).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]

        public IActionResult Add(PedidoTipoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    PedidoTipo oPT = new PedidoTipo();
                    oPT.TipNombre = oModel.TipNombre;
                    oPT.TipDescripcion = oModel.TipDescripcion;
                    oPT.TipEstado = oModel.TipEstado;

                    db.PedidoTipos.Add(oPT);
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
        public IActionResult Edit(PedidoTipoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    PedidoTipo oPT = db.PedidoTipos.Find(oModel.TipId);
                    oPT.TipNombre = oModel.TipNombre;
                    oPT.TipDescripcion = oModel.TipDescripcion;
                    oPT.TipEstado = oModel.TipEstado;

                    db.Entry(oPT).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    PedidoTipo oPT = db.PedidoTipos.Find(Id);
                    db.Remove(oPT);
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
