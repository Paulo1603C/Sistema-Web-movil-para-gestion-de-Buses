using Entidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrecuenciaParadaController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FrecuenciaParadaEntidad>>> Get()
        {
            return FrecuenciaParadaNegocio.ListarFrecuenciasParada();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FrecuenciaParadaEntidad>> Get(int id)
        {
            return FrecuenciaParadaNegocio.ObtenerFrecuenciaParadaPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<FrecuenciaParadaEntidad>> Post(FrecuenciaParadaEntidad frecuenciaParadaEntidad)
        {
            FrecuenciaParadaEntidad frecuenciaParada = FrecuenciaParadaNegocio.Crear(frecuenciaParadaEntidad);
            return frecuenciaParada;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FrecuenciaParadaEntidad>> Put(int id, FrecuenciaParadaEntidad frecuenciaParadaEntidad)
        {
            if (id != frecuenciaParadaEntidad.Id)
            {
                return BadRequest();
            }
            try
            {
                return FrecuenciaParadaNegocio.Actualizar(frecuenciaParadaEntidad);
            }
            catch (Exception)
            {
                FrecuenciaParadaEntidad frecuenciaParada = FrecuenciaParadaNegocio.ObtenerFrecuenciaParadaPorId(id);
                if (frecuenciaParada == null)
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
            var frecuenciaParada = FrecuenciaParadaNegocio.ObtenerFrecuenciaParadaPorId(id);
            if (frecuenciaParada == null)
            {
                return NotFound();
            }
            else
            {
                return FrecuenciaParadaNegocio.Eliminar(id);
            }

            return NoContent();
        }
    }
}
