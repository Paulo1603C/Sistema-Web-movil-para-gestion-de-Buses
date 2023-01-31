using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class DetalleViajeEntidad
    {
        public int Id { get; set; }
        public int IdViaje { get; set; }
        public int IdAsiento { get; set; }
        public string Estado { get; set; }

        public int Orden { get; set; }
        public string DesAsiento { get; set; }
        public int IdBus { get; set; }
        public string NumBus { get; set; }
        public int Anio { get; set; }
        public string MarcaCh { get; set; }
        public string ModeloCar { get; set; }
        public int Pisos { get; set; }
        public string RamvCpn { get; set; }
        public string RutaImagen { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public string Recargo { get; set; }
        public int IdCooperativa { get; set; }
        public string Cooperativa { get; set; }
        public string Telefono { get; set; }
        public string PaginaWeb { get; set; }
    }
}
