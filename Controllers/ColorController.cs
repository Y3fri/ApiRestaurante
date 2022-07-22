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
    public class ColorController : ControllerBase
    { 
            private readonly IColorService _colorService;

            public ColorController(IColorService colorService)
            {
                _colorService = colorService;
            }

            [HttpGet]
            public IActionResult Get()
            {
                Respuesta oRespuesta = new Respuesta();

                try
                {

                    oRespuesta.Data = _colorService.get();
                    oRespuesta.Exito = 1;


                }
                catch (Exception ex)
                {
                    oRespuesta.Mensaje = ex.Message;
                }
                return Ok(oRespuesta);
            }

            [HttpPost]

            public IActionResult Add(ColorRequest oModel)
            {
                Respuesta oRespuesta = new Respuesta();
                try
                {
                    using (RestauranteBDContext db = new RestauranteBDContext())
                    {
                        Color oColor = new Color();
                        oColor.ColRestarurante = oModel.ColRestarurante;
                        oColor.ColFondo = oModel.ColFondo;
                        oColor.ColFuente = oModel.ColFuente;
                        oColor.ColEncabezado = oModel.ColEncabezado;
                    oColor.ColTitulos = oModel.ColTitulos;
                    oColor.ColTitEncabezado = oModel.ColEncabezado;
                    oColor.ColTituMenu = oModel.ColTituMenu;
                    oColor.ColConteMenu = oModel.ColConteMenu;



                    db.Colors.Add(oColor);
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
            public IActionResult Edit(ColorRequest oModel)
            {
                Respuesta oRespuesta = new Respuesta();
                try
                {
                    using (RestauranteBDContext db = new RestauranteBDContext())
                    {
                       Color oColor = db.Colors.Find(oModel.ColId);
                    oColor.ColRestarurante = oModel.ColRestarurante;
                    oColor.ColFondo = oModel.ColFondo;
                    oColor.ColFuente = oModel.ColFuente;
                    oColor.ColEncabezado = oModel.ColEncabezado;
                    oColor.ColTitulos = oModel.ColTitulos;
                    oColor.ColTitEncabezado = oModel.ColTitEncabezado;
                    oColor.ColTituMenu= oModel.ColTituMenu;
                    oColor.ColConteMenu=oModel.ColConteMenu;

                    db.Entry(oColor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                        Color oColor = db.Colors.Find(Id);
                        db.Remove(oColor);
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
