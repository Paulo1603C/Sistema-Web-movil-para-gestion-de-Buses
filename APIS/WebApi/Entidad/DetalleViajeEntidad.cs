using Microsoft.AspNetCore.Http;
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
        public decimal Recargo { get; set; }
        public int IdCooperativa { get; set; }
        public string Cooperativa { get; set; }
        public string Telefono { get; set; }
        public string PaginaWeb { get; set; }
        public decimal PrecioBase { get; set; }
        public decimal PrecioFinal { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraSalida { get; set; }
        public int IdCliente { get; set; }
        public string? Cliente { get; set; }
        public string? Evidencia { get; set; }
        public int IdFormaPago { get; set; }
        public string? FormaPago { get; set; }
        public int IdUsuarioConfirma { get; set; }
        public string? UsuarioConfirma { get; set; }
        public string? Observacion { get; set; }
        public byte[]? Imagen { get; set; }

    }
}
