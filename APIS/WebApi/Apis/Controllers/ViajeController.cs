using Entidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : ControllerBase
    {
        [HttpPost("/buscar")]
        public async Task<ActionResult<IEnumerable<ViajeEntidad>>> BuscarViajes([FromBody]FiltrosViaje filtros)
        {
            if (filtros == null) filtros= new FiltrosViaje();
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

    }
}
