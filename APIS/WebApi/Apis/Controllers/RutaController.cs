using Entidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutaController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RutaEntidad>>> Get()
        {
            return RutaNegocio.ListarRutas();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RutaEntidad>> Get(int id)
        {
            return RutaNegocio.ObtenerRutaPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<RutaEntidad>> Post(RutaEntidad rutaEntidad)
        {
            RutaEntidad ruta = RutaNegocio.Crear(rutaEntidad);
            return ruta;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RutaEntidad>> Put(int id, RutaEntidad rutaEntidad)
        {
            if (id != rutaEntidad.Id)
            {
                return BadRequest();
            }
            try
            {
                return RutaNegocio.Actualizar(rutaEntidad);
            }
            catch (Exception)
            {
                RutaEntidad ruta = RutaNegocio.ObtenerRutaPorId(id);
                if (ruta == null)
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
            var ruta = RutaNegocio.ObtenerRutaPorId(id);
            if (ruta == null)
            {
                return NotFound();
            }
            else
            {
                return RutaNegocio.Eliminar(id);
            }

            return NoContent();
        }
    }
}
