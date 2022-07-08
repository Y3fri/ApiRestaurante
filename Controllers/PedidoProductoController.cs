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
    public class PedidoProductoController : ControllerBase
    {
        private readonly IPProductoService _pproductoService;

        public PedidoProductoController(IPProductoService pproductoService)
        {
            _pproductoService = pproductoService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    oRespuesta.Data = _pproductoService.get();
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

        public IActionResult Add(PedidoProductoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    PedidoProducto oPP = new PedidoProducto();
                    oPP.ProProducto = oModel.ProProducto;
                    oPP.ProEstado = oModel.ProEstado;
                    oPP.ProSolicitudAdicional = oModel.ProSolicitudAdicional;
                    db.PedidoProductos.Add(oPP);
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
        public IActionResult Edit(PedidoProductoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    PedidoProducto oPP = db.PedidoProductos.Find(oModel.ProId);
                    oPP.ProProducto = oModel.ProProducto;
                    oPP.ProEstado = oModel.ProEstado;
                    oPP.ProSolicitudAdicional = oModel.ProSolicitudAdicional;
                    db.Entry(oPP).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    PedidoProducto oPP = db.PedidoProductos.Find(Id);
                    db.Remove(oPP);
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
