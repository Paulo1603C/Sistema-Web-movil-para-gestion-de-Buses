using Entidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolController : ControllerBase
    {
        // GET: api/<RolController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolEntidad>>> Get()
        {
            return  RolNegocio.ListarRoles();
        }

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolEntidad>> Get(int id)
        {
            return RolNegocio.ObtenerRolPorId(id);  
        }

        // POST api/<RolController>
        [HttpPost]
        public async Task<ActionResult<RolEntidad>> Post(RolEntidad rolEntidad)
        {
            RolEntidad rol= RolNegocio.Crear(rolEntidad);
            return rol;
        }

        // PUT api/<RolController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RolEntidad>> Put(int id, RolEntidad rolEntidad)
        {
            if (id != rolEntidad.Id)
            {
                return BadRequest();
            }
            try
            {
                return RolNegocio.Actualizar(rolEntidad);
            }
            catch (Exception)
            {
                RolEntidad rol = RolNegocio.ObtenerRolPorId(id);
                if (rol==null)
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

        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public  dynamic Delete(int id)
        {
            var rol = RolNegocio.ObtenerRolPorId(id);
            if (rol == null)
            {
                return NotFound();
            }
            else
            {
                return RolNegocio.Eliminar(id);
            }

            return NoContent();
        }
    }
}
