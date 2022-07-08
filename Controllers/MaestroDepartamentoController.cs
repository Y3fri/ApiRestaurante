using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Request;
using Restaurant.Models.Response;
using Restaurant.Models.Services;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaestroDepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;

        public MaestroDepartamentoController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }
     
            [HttpGet]
            public IActionResult Get()
            {
                Respuesta oRespuesta = new Respuesta();

                try
                {

                        oRespuesta.Data = _departamentoService.get();
                        oRespuesta.Exito = 1;
                        
                  
                }
                catch (Exception ex)
                {
                    oRespuesta.Mensaje = ex.Message;
                }
                return Ok(oRespuesta);
            }

            [HttpPost]

            public IActionResult Add(MaestroDepartamentoRequest oModel)
            {
                Respuesta oRespuesta = new Respuesta();
                try
                {
                    using (RestauranteBDContext db = new RestauranteBDContext())
                    {
                        MaestroDepartamento oMD = new MaestroDepartamento();
                        oMD.DepPais = oModel.DepPais;
                        oMD.DepCodigoDane = oModel.DepCodigoDane;
                        oMD.DepNombre = oModel.DepNombre;
                        
                        db.MaestroDepartamentos.Add(oMD);
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
            public IActionResult Edit(MaestroDepartamentoRequest oModel)
            {
                Respuesta oRespuesta = new Respuesta();
                try
                {
                    using (RestauranteBDContext db = new RestauranteBDContext())
                    {
                        MaestroDepartamento oMD = db.MaestroDepartamentos.Find(oModel.DepId);
                        oMD.DepPais = oModel.DepPais;
                        oMD.DepCodigoDane = oModel.DepCodigoDane;
                        oMD.DepNombre = oModel.DepNombre;

                        db.Entry(oMD).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                        MaestroDepartamento oMD = db.MaestroDepartamentos.Find(Id);
                        db.Remove(oMD);
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





