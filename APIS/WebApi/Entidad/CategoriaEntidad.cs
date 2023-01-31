using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class CategoriaEntidad
    {
        public int? Id { get; set; }
        public string Descripcion { get; set; }
        public int IdCooperativa { get; set; }
        public string? Cooperativa { get; set; }
    }
}
