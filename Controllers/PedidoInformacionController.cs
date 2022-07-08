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
    public class PedidoInformacionController : ControllerBase
    {
        private readonly IPInfService _pinfService;

        public PedidoInformacionController(IPInfService pinfService)
        {
            _pinfService = pinfService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {

                
                    oRespuesta.Data = _pinfService.get();
                    oRespuesta.Exito = 1;
                    
                
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]

        public IActionResult Add(PedidoInformacionRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    PedidoInformacion oPI = new PedidoInformacion();
                    oPI.InfTipo = oModel.InfTipo;
                    oPI.InfMunicipio = oModel.InfMunicipio;
                    oPI.InfTipoPago = oModel.InfTipoPago;
                    oPI.InfEstado  = oModel.InfEstado;
                    oPI.InfNombreCliente = oModel.InfNombreCliente;
                    oPI.InfDireccion = oModel.InfDireccion;
                    oPI.InfTelefono = oModel.InfTelefono;
                    oPI.InfNumeroPiso = oModel.InfNumeroPiso;
                    oPI.InfNumeroMesa = oModel.InfNumeroMesa;
                   

                    db.PedidoInformacions.Add(oPI);
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
        public IActionResult Edit(PedidoInformacionRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (RestauranteBDContext db = new RestauranteBDContext())
                {
                    PedidoInformacion oPI = db.PedidoInformacions.Find(oModel.InfId);
                    oPI.InfTipo = oModel.InfTipo;
                    oPI.InfMunicipio = oModel.InfMunicipio;
                    oPI.InfTipoPago = oModel.InfTipoPago;
                    oPI.InfEstado = oModel.InfEstado;
                    oPI.InfNombreCliente = oModel.InfNombreCliente;
                    oPI.InfDireccion = oModel.InfDireccion;
                    oPI.InfTelefono = oModel.InfTelefono;
                    oPI.InfNumeroPiso = oModel.InfNumeroPiso;
                    oPI.InfNumeroMesa = oModel.InfNumeroMesa;


                    db.Entry(oPI).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    PedidoInformacion oPI = db.PedidoInformacions.Find(Id);
                    db.Remove(oPI);
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
