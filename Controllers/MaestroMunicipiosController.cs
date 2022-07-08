
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Request;
using Restaurant.Models.Response;
using Restaurant.Models.Services;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaestroMunicipiosController : ControllerBase
    {

        private readonly IMunicipioService _municipioService;

        public MaestroMunicipiosController(IMunicipioService municipioService)
        {
            _municipioService = municipioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                oRespuesta.Data = _municipioService.get();
                oRespuesta.Exito = 1;


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }



        [HttpPost]

            public IActionResult Add(MaestroMunicipioRequest oModel)
            {
                Respuesta oRespuesta = new Respuesta();
                try
                {
                    using (RestauranteBDContext db = new RestauranteBDContext())
                    {
                        MaestroMunicipio oMM = new MaestroMunicipio();
                        oMM.MunDepartamento = oModel.MunDepartamento;
                        oMM.MunCodigoDane = oModel.MunCodigoDane;
                        oMM.MunNombre = oModel.MunNombre;
                        db.MaestroMunicipios.Add(oMM);
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
            public IActionResult Edit(MaestroMunicipioRequest oModel)
            {
                Respuesta oRespuesta = new Respuesta();
                try
                {
                    using (RestauranteBDContext db = new RestauranteBDContext())
                    {
                        MaestroMunicipio oMM = db.MaestroMunicipios.Find(oModel.MunId);
                        oMM.MunDepartamento = oModel.MunDepartamento;
                        oMM.MunCodigoDane = oModel.MunCodigoDane;
                        oMM.MunNombre = oModel.MunNombre;

                        db.Entry(oMM).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                        MaestroMunicipio oMM = db.MaestroMunicipios.Find(Id);
                        db.Remove(oMM);
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



