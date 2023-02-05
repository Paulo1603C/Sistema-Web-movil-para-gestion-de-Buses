using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ConfirmaPago

    {
        public int IdAsientoViaje { get; set; }
        public int IdUsuario { get; set; }
        public string Estado { get; set; }
        public string?  Observacion { get; set; }

    }
}
