using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class UsuarioEntidad
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string TipoIdentificacion { get; set; } = null!;

        public string? NumeroIdentificacion { get; set; }

        public string? Telefono { get; set; }

        public string? Correo { get; set; }

        public string? Direccion { get; set; }

        public string Usuario { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int IdRol { get; set; }
        public string? Rol { get; set; }
    }
}
