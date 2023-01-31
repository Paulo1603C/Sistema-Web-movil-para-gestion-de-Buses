using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class LugarEntidad
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public decimal? Latitud { get; set; }

        public decimal? Longitud { get; set; }

        public string? Canton { get; set; }

        public string? Provincia { get; set; }
    }
}
