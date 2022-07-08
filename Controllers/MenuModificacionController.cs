using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Request;
using Restaurant.Models.Response;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuModificacionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    var lst = db.MenuModificacions.OrderByDescending(d => d.ModId).ToList();
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

        public IActionResult Add(MenuModificacionRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    MenuModificacion oMod = new MenuModificacion();
                    oMod.ModNombre = oModel.ModNombre;
                   
                    db.MenuModificacions.Add(oMod);
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
        public IActionResult Edit(MenuModificacionRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    MenuModificacion oMod = db.MenuModificacions.Find(oModel.ModId);
                    oMod.ModNombre = oModel.ModNombre;

                    db.Entry(oMod).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    MenuModificacion oMod = db.MenuModificacions.Find(Id);
                    db.Remove(oMod);
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
