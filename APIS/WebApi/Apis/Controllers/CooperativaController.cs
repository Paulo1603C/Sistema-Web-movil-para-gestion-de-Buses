using Entidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CooperativaController : ControllerBase
    {
        
        // GET: api/<UsuarioContusuarioler>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CooperativaEntidad>>> Get()
        {
            return CooperativaNegocio.ListarCooperativas();
        }
      

        // GET api/<UsuarioContusuarioler>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CooperativaEntidad>> Get(int id)
        {
            return CooperativaNegocio.ObtenerCooperativaPorId(id);
        }
       
        // POST api/<UsuarioContusuarioler>
        [HttpPost]
        public async Task<ActionResult<CooperativaEntidad>> Post(CooperativaEntidad cooperativaEntidad)
        {
            CooperativaEntidad cooperativa = CooperativaNegocio.Crear(cooperativaEntidad);
            return cooperativa;
        }
        
        // PUT api/<UsuarioContusuarioler>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CooperativaEntidad>> Put(int id, CooperativaEntidad cooperativaEntidad)
        {
            if (id != cooperativaEntidad.Id)
            {
                return BadRequest();
            }
            try
            {
                return CooperativaNegocio.Actualizar(cooperativaEntidad);
            }
            catch (Exception)
            {
                CooperativaEntidad usuario = CooperativaNegocio.ObtenerCooperativaPorId(id);
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
        
        // DELETE api/<UsuarioContusuarioler>/5
        [HttpDelete("{id}")]
        public dynamic Delete(int id)
        {
            var usuario = CooperativaNegocio.ObtenerCooperativaPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return CooperativaNegocio.Eliminar(id);
            }

            return NoContent();
        }
    }
}
