using Entidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientoController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsientoEntidad>>> Get()
        {
            return AsientoNegocio.ListarAsientos();
        }
        [HttpGet("/PorBus/{IdBus}")]
        public async Task<ActionResult<IEnumerable<AsientoEntidad>>> GetListaPorIdBus(int IdBus)
        {
            return AsientoNegocio.ListarAsientosPorIdBus(IdBus);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AsientoEntidad>> Get(int id)
        {
            return AsientoNegocio.ObtenerAsientoPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<AsientoEntidad>> Post(AsientoEntidad asientoEntidad)
        {
            AsientoEntidad asiento = AsientoNegocio.Crear(asientoEntidad);
            return asiento;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AsientoEntidad>> Put(int id, AsientoEntidad asientoEntidad)
        {
            if (id != asientoEntidad.Id)
            {
                return BadRequest();
            }
            try
            {
                return AsientoNegocio.Actualizar(asientoEntidad);
            }
            catch (Exception)
            {
                AsientoEntidad asiento = AsientoNegocio.ObtenerAsientoPorId(id);
                if (asiento == null)
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
            var asiento = AsientoNegocio.ObtenerAsientoPorId(id);
            if (asiento == null)
            {
                return NotFound();
            }
            else
            {
                return AsientoNegocio.Eliminar(id);
            }

            return NoContent();
        }
    }
}
