using Entidad;
using Microsoft.AspNetCore.Mvc;
using Negocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // GET: api/<UsuarioContusuarioler>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioEntidad>>> Get()
        {
            return UsuarioNegocio.ListarUsuarios();
        }

        // GET api/<UsuarioContusuarioler>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioEntidad>> Get(int id)
        {
            return UsuarioNegocio.ObtenerUsuarioPorId(id);
        }

        // POST api/<UsuarioContusuarioler>
        [HttpPost]
        public async Task<ActionResult<UsuarioEntidad>> Post(UsuarioEntidad usuarioEntidad)
        {
            UsuarioEntidad usuario = UsuarioNegocio.Crear(usuarioEntidad);
            return usuario;
        }

        // PUT api/<UsuarioContusuarioler>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioEntidad>> Put(int id, UsuarioEntidad usuarioEntidad)
        {
            if (id != usuarioEntidad.Id)
            {
                return BadRequest();
            }
            try
            {
                return UsuarioNegocio.Actualizar(usuarioEntidad);
            }
            catch (Exception)
            {
                UsuarioEntidad usuario = UsuarioNegocio.ObtenerUsuarioPorId(id);
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
            var usuario = UsuarioNegocio.ObtenerUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return UsuarioNegocio.Eliminar(id);
            }

            return NoContent();
        }
    }
}
