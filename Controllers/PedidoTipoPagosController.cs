using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Request;
using Restaurant.Models.Response;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoTipoPagosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    var lst = db.PedidoTipoPagos.OrderByDescending(d => d.TipaId).ToList();
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

        public IActionResult Add(PedidoTipoPagoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    PedidoTipoPago oPTP = new PedidoTipoPago();
                    oPTP.TipaNombre = oModel.TipaNombre;
                    oPTP.TipaDescripcion = oModel.TipaDescripcion;
                    oPTP.TipaEstado = oModel.TipaEstado;
                    
                    db.PedidoTipoPagos.Add(oPTP);
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
        public IActionResult Edit(PedidoTipoPagoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    PedidoTipoPago oPTP = db.PedidoTipoPagos.Find(oModel.TipaId);
                    oPTP.TipaNombre = oModel.TipaNombre;
                    oPTP.TipaDescripcion = oModel.TipaDescripcion;
                    oPTP.TipaEstado = oModel.TipaEstado;


                    db.Entry(oPTP).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    PedidoTipoPago oPTP = db.PedidoTipoPagos.Find(Id);
                    db.Remove(oPTP);
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
