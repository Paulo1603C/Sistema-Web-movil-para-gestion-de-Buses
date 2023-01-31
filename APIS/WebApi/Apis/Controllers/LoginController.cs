using Entidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Negocio;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly string _secretKey;

        public LoginController(IConfiguration config)
        {
            _secretKey= config.GetSection("settings").GetSection("secretKey").ToString();
        }

        [HttpPost]
        [Route("Validar")]
        public IActionResult Validar([FromBody] LoginEntidad request)
        {
            //Consultar a base de datos
            UsuarioEntidad usuarioEntidad= UsuarioNegocio.ObtenerUsuarioLogin(request);
            //retornar usuario o bool
            if (usuarioEntidad!=null)
            {
                var keyBytes = Encoding.ASCII.GetBytes(_secretKey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.UserName));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig= tokenHandler.CreateToken(tokenDescriptor);

                string tokenCreado = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new { token = tokenCreado, usuario= usuarioEntidad });

            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { result = "Usuario o contraseña no registrado" });
            }
        }
    }
}
