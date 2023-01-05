using Entidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace WebApi.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class RolController : ControllerBase
        {

            private readonly ILogger<RolController> _logger;

            public RolController(ILogger<RolController> logger)
            {
                _logger = logger;
            }

        // POST: RolController/Create
        [HttpPost]
        public RolEntidad Create([FromBody] RolEntidad rolEntidad)
        {
            try
            {
                return RolNegocio.crearRol(rolEntidad);

            }
            catch
            {
                return null;
            }
        }


    }
}
