using Entidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusEntidad>>> Get()
        {
            return BusNegocio.ListarBuses();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BusEntidad>> Get(int id)
        {
            return BusNegocio.ObtenerBusPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<BusEntidad>> Post(BusEntidad busEntidad)
        {
            BusEntidad bus = BusNegocio.Crear(busEntidad);
            return bus;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BusEntidad>> Put(int id, BusEntidad busEntidad)
        {
            if (id != busEntidad.Id)
            {
                return BadRequest();
            }
            try
            {
                return BusNegocio.Actualizar(busEntidad);
            }
            catch (Exception)
            {
                BusEntidad bus = BusNegocio.ObtenerBusPorId(id);
                if (bus == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public dynamic Delete(int id)
        {
            var bus = BusNegocio.ObtenerBusPorId(id);
            if (bus == null)
            {
                return NotFound();
            }
            else
            {
                return BusNegocio.Eliminar(id);
            }

            return NoContent();
        }
    }
}
