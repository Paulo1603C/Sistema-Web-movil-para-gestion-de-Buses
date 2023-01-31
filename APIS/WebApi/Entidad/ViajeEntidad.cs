using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ViajeEntidad
    {
        public int IdViaje { get; set; }
        public string Fecha { get; set; }

        public int IdCooperativa { get; set; }
        public string Cooperativa { get; set; }
        public string Representante { get; set; }
        public string PaginaWeb { get; set; }
        public string Telefono { get; set; }
        public int IdFrecuencia { get; set; }
        public string HoraSalida { get; set; }
        public string HoraArribo { get; set; }
        public int IdRuta { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public int NumAsientosDisponibles{ get; set; }
        public int NumParadas { get; set; }
        public int IdBus { get; set; }
        public int Anio { get; set; }
        public int Capacidad { get; set; }
        public string MarcaCh { get; set; }
        public string Numero { get; set; }
        public string RamvCpn { get; set; }
    }
}
