using Entidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using System.Text;

namespace Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ViajeController(IWebHostEnvironment webHost)
        {
            _webHostEnvironment = webHost;
        }
        [HttpPost("/buscar")]
        public async Task<ActionResult<IEnumerable<ViajeEntidad>>> BuscarViajes([FromBody] FiltrosViaje filtros)
        {
            if (filtros == null) filtros = new FiltrosViaje();
            return ViajeNegocio.BuscarViajes(filtros);
        }
        [HttpGet("/asientos/{id}")]
        public async Task<ActionResult<IEnumerable<DetalleViajeEntidad>>> ListarDetalleViajePorIdViaje(int id)
        {
            return ViajeNegocio.ListarDetalleViajePorIdViaje(id);
        }

        [HttpGet("/reservarAsiento/{idUsuario}/{idAsiento}")]
        public dynamic ReservarAsiento(int idUsuario, int idAsiento)
        {

            return ViajeNegocio.ReservarAsiento(idUsuario, idAsiento);
        }
        [HttpGet("/cerrar/{id}")]
        public dynamic CerrarViaje(int id)
        {

            return ViajeNegocio.CerrarViaje(id);
        }
        [HttpGet("/crear/{fechaFin}")]
        public dynamic CrearViajes(string fechaFin)
        {

            return ViajeNegocio.CrearViajes(fechaFin);
        }
        [HttpGet("/crearDetalle")]
        public dynamic CrearDetalleViajes()
        {

            return ViajeNegocio.CrearDetalleViajes();
        }
        [HttpPost("/compraBoleto/")]
        public async Task<IActionResult> CompraBoleto([FromForm] ComprobanteEntidad comprobante)
        {
            try
            {
                //DetalleViajeEntidad detalleViaje = ViajeNegocio.ObtenerDetalleViajePorId(comprobante.IdAsientoViaje);
                if (comprobante.Comprobante.Length == 0)
                    return BadRequest("Error en length");
                var path = Path.Combine(_webHostEnvironment.ContentRootPath, "Files");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fullPath = Path.Combine(path, "Ar_" + comprobante.IdAsientoViaje + comprobante.Comprobante.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    comprobante.Comprobante.CopyTo(stream);
                }
                comprobante.RutaComprobante = fullPath;
                ViajeNegocio.CompraBoleto(comprobante);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message.ToString());
            }


        }
        [HttpGet("/listaFormasPago")]
        public async Task<ActionResult<IEnumerable<FormaPago>>> ListaFormaPago()
        {
            return ViajeNegocio.ListaFormaPago();
        }
        [HttpPost("/confirmarViaje")]
        public dynamic ConfirmarViaje(ConfirmaPago confirma)
        {

            return ViajeNegocio.ConfirmarPago(confirma);
        }
        [HttpGet("/listaPorEstado/{Estado}/{IdCooperativa}")]
        public List<DetalleViajeEntidad> ListarDetalleViajePorEstado(string Estado, int IdCooperativa)
        {
            return ViajeNegocio.ListarDetalleViajePorEstado(Estado, IdCooperativa);
        }
        [HttpGet("/DetalleViaje/{Id}")]
        public DetalleViajeEntidad ObtenerDetalleViajePorId(int Id)
        {
            return ViajeNegocio.ObtenerDetalleViajePorId(Id);
        }
        [HttpGet("/DescargarComprobante/{Id}" )]
        public async Task<ActionResult<IEnumerable<FormaPago>>> DescargarComprobante(int Id)
        {
            DetalleViajeEntidad detalle= ViajeNegocio.ObtenerDetalleViajePorId(Id);
            return File(detalle.Imagen,"image/jpg",fileDownloadName:"tmp.jpg");
        }

    }
}
