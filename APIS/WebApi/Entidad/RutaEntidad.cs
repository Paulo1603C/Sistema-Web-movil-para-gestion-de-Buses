using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class RutaEntidad
    {
        public int? Id { get; set; }
        public string Descripcion { get; set; }
        public int IdLugarOrigen { get; set; }
        public string? LugarOrigen { get; set; }

        public int IdLugarDestino { get; set; }
        public string? LugarDestino { get; set; }

    }
}
