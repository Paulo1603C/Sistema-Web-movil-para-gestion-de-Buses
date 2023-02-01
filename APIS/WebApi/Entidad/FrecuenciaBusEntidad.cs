using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class FrecuenciaBusEntidad
    {
        public int? Id { get; set; }

        public int? IdFrecuencia { get; set; }
        public string? Frecuencia { get; set; }

        public int? IdBus { get; set; }
        public string? Bus { get; set; }

        public bool? Habilitado { get; set; }

        public int? IdUsuarioH { get; set; }
        public string? UsuarioH { get; set; }
    }
}
