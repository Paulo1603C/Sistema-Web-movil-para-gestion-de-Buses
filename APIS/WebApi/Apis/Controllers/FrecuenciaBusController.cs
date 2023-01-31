using Entidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrecuenciaBusController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FrecuenciaBusEntidad>>> Get()
        {
            return FrecuenciaBusNegocio.ListarFrecuenciasBus();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FrecuenciaBusEntidad>> Get(int id)
        {
            return FrecuenciaBusNegocio.ObtenerFrecuenciaBusPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<FrecuenciaBusEntidad>> Post(FrecuenciaBusEntidad frecuenciaBusEntidad)
        {
            FrecuenciaBusEntidad frecuenciaBus = FrecuenciaBusNegocio.Crear(frecuenciaBusEntidad);
            return frecuenciaBus;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FrecuenciaBusEntidad>> Put(int id, FrecuenciaBusEntidad frecuenciaBusEntidad)
        {
            if (id != frecuenciaBusEntidad.Id)
            {
                return BadRequest();
            }
            try
            {
                return FrecuenciaBusNegocio.Actualizar(frecuenciaBusEntidad);
            }
            catch (Exception)
            {
                FrecuenciaBusEntidad frecuenciaBus = FrecuenciaBusNegocio.ObtenerFrecuenciaBusPorId(id);
                if (frecuenciaBus == null)
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
            var frecuenciaBus = FrecuenciaBusNegocio.ObtenerFrecuenciaBusPorId(id);
            if (frecuenciaBus == null)
            {
                return NotFound();
            }
            else
            {
                return FrecuenciaBusNegocio.Eliminar(id);
            }

            return NoContent();
        }
    }
}
