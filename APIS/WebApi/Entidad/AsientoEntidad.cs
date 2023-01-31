using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class AsientoEntidad
    {
        public int? Id { get; set; }

        public int? IdBus { get; set; }
        public string? Bus { get; set; }

        public int? Orden { get; set; }

        public string? Descripcion { get; set; }

        public int? IdCategoria { get; set; }
        public string? Categoria { get; set; }
    }
}
