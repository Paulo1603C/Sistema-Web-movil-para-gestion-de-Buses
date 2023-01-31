using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class FrecuenciaEntidad
    {
        public int? Id { get; set; }

        public int IdRuta { get; set; }
        public string? Ruta { get; set; }
        public int IdCooperativa { get; set; }
        public string? Cooperativa { get; set; }
        public string HoraSalida { get; set; }
        public string? HoraArribo { get; set; }
        public bool? Habilitado { get; set; }
        public int? IdUsuarioH { get; set; }
        public string? UsuarioH { get; set; }
        public string? DiaSemana { get; set; }
        public decimal Precio { get; set; }


    }
}
