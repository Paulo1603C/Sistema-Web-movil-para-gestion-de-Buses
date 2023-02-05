using Entidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrecuenciaController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FrecuenciaEntidad>>> Get()
        {
            return FrecuenciaNegocio.ListarFrecuencias();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FrecuenciaEntidad>> Get(int id)
        {
            return FrecuenciaNegocio.ObtenerFrecuenciaPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<FrecuenciaEntidad>> Post(FrecuenciaEntidad frecuenciaEntidad)
        {
            FrecuenciaEntidad frecuencia = FrecuenciaNegocio.Crear(frecuenciaEntidad);
            return frecuencia;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FrecuenciaEntidad>> Put(int id, FrecuenciaEntidad frecuenciaEntidad)
        {
            if (id != frecuenciaEntidad.Id)
            {
                return BadRequest();
            }
            try
            {
                return FrecuenciaNegocio.Actualizar(frecuenciaEntidad);
            }
            catch (Exception)
            {
                FrecuenciaEntidad frecuencia = FrecuenciaNegocio.ObtenerFrecuenciaPorId(id);
                if (frecuencia == null)
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
            var frecuencia = FrecuenciaNegocio.ObtenerFrecuenciaPorId(id);
            if (frecuencia == null)
            {
                return NotFound();
            }
            else
            {
                return FrecuenciaNegocio.Eliminar(id);
            }

            return NoContent();
        }
        [HttpGet("/api/HabilitarFrecuencia/{IdFrecuencia}/{IdUsuario}")]
        public dynamic HabilitarFrecuencia(string IdFrecuencia, string IdUsuario)
        {
            var frecuencia = FrecuenciaNegocio.ObtenerFrecuenciaPorId(Convert.ToInt32(IdFrecuencia));
            if (frecuencia == null)
            {
                return NotFound();
            }
            else
            {
                return FrecuenciaNegocio.HabilitarFrecuencia(IdFrecuencia, IdUsuario);
            }

            return NoContent();
        }
    }
}
