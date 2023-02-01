using Entidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugarController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LugarEntidad>>> Get()
        {
            return LugarNegocio.ListarLugares();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LugarEntidad>> Get(int id)
        {
            return LugarNegocio.ObtenerLugarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<LugarEntidad>> Post(LugarEntidad lugarEntidad)
        {
            LugarEntidad lugar = LugarNegocio.Crear(lugarEntidad);
            return lugar;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LugarEntidad>> Put(int id, LugarEntidad lugarEntidad)
        {
            if (id != lugarEntidad.Id)
            {
                return BadRequest();
            }
            try
            {
                return LugarNegocio.Actualizar(lugarEntidad);
            }
            catch (Exception)
            {
                LugarEntidad usuario = LugarNegocio.ObtenerLugarPorId(id);
                if (usuario == null)
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
            var usuario = LugarNegocio.ObtenerLugarPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return LugarNegocio.Eliminar(id);
            }

            return NoContent();
        }
    }
}
