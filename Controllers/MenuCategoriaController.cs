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
    public class MenuCategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public MenuCategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _categoriaService.get();
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]

        public IActionResult Add(MenuCategoriaRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    MenuCategorium oCategory = new MenuCategorium();
                    oCategory.CarSede = oModel.CarSede;
                    oCategory.CatNombre = oModel.CatNombre;
                    oCategory.CatDescripcion = oModel.CatDescripcion;
                    oCategory.CatEstado = oModel.CatEstado;
                    db.MenuCategoria.Add(oCategory);
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
        public IActionResult Edit(MenuCategoriaRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    MenuCategorium oCategory = db.MenuCategoria.Find(oModel.CatId);
                    oCategory.CarSede = oModel.CarSede;
                    oCategory.CatNombre = oModel.CatNombre;
                    oCategory.CatDescripcion = oModel.CatDescripcion;
                    oCategory.CatEstado = oModel.CatEstado;

                    db.Entry(oCategory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    MenuCategorium oCategory = db.MenuCategoria.Find(Id);
                    db.Remove(oCategory);
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
