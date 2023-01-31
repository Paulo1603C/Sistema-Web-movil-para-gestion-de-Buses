using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class BusEntidad
    {
        public int? Id { get; set; }

        public int? IdCooperativa { get; set; }
        public string? Cooperativa { get; set; }

        public string? Numero { get; set; }

        public int? Anio { get; set; }

        public string? RamvCpn { get; set; }

        public string? ModeloCar { get; set; }

        public string? MarcaCh { get; set; }

        public string? Transporte { get; set; }

        public int Pisos { get; set; }

        public int Capacidad { get; set; }

        public int Puertas { get; set; }

        public string? RutaImagen { get; set; }

    }
}
