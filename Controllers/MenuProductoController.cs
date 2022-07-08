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
    public class MenuProductoController : ControllerBase
    {
        private readonly IMProductoService _productoService;

        public MenuProductoController(IMProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _productoService.get();
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        [HttpPost]

        public IActionResult Add(MenuProductoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    MenuProducto oProducto = new MenuProducto();
                    oProducto.ProCategoria = oModel.ProCategoria;
                    oProducto.ProSede = oModel.ProSede;
                    oProducto.ProNombre = oModel.ProNombre;
                    oProducto.ProDescripcion = oModel.ProDescripcion;
                    oProducto.ProPrecio = oModel.ProPrecio;
                    oProducto.ProFoto = oModel.ProFoto;
                    oProducto.ProVideo = oModel.ProVideo;
                    oProducto.ProTiempoPreparacion = oModel.ProTiempoPreparacion;
                    oProducto.ProEstado = oModel.ProEstado;

                    db.MenuProductos.Add(oProducto);
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
        public IActionResult Edit(MenuProductoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    MenuProducto oProducto = db.MenuProductos.Find(oModel.ProId);
                    oProducto.ProCategoria = oModel.ProCategoria;
                    oProducto.ProSede = oModel.ProSede;
                    oProducto.ProNombre = oModel.ProNombre;
                    oProducto.ProDescripcion = oModel.ProDescripcion;
                    oProducto.ProPrecio = oModel.ProPrecio;
                    oProducto.ProFoto = oModel.ProFoto;
                    oProducto.ProVideo = oModel.ProVideo;
                    oProducto.ProTiempoPreparacion = oModel.ProTiempoPreparacion;
                    oProducto.ProEstado = oModel.ProEstado;
                    db.Entry(oProducto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    MenuProducto oProducto = db.MenuProductos.Find(Id);
                    db.Remove(oProducto);
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
