using Entidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaEntidad>>> Get()
        {
            return CategoriaNegocio.ListarCategorias();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaEntidad>> Get(int id)
        {
            return CategoriaNegocio.ObtenerCategoriaPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaEntidad>> Post(CategoriaEntidad categoriaEntidad)
        {
            CategoriaEntidad categoria = CategoriaNegocio.Crear(categoriaEntidad);
            return categoria;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriaEntidad>> Put(int id, CategoriaEntidad categoriaEntidad)
        {
            if (id != categoriaEntidad.Id)
            {
                return BadRequest();
            }
            try
            {
                return CategoriaNegocio.Actualizar(categoriaEntidad);
            }
            catch (Exception)
            {
                CategoriaEntidad categoria = CategoriaNegocio.ObtenerCategoriaPorId(id);
                if (categoria == null)
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
            var categoria = CategoriaNegocio.ObtenerCategoriaPorId(id);
            if (categoria == null)
            {
                return NotFound();
            }
            else
            {
                return CategoriaNegocio.Eliminar(id);
            }

            return NoContent();
        }
    }
}
