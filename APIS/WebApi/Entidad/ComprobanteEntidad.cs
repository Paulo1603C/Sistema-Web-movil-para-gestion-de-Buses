using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ComprobanteEntidad
    {
        public int IdAsientoViaje { get; set; }
        public int IdCliente { get; set; }
        public int IdFormaPago { get; set; }
        public IFormFile? Comprobante { get; set; }
        public string? RutaComprobante { get; set; }
        public decimal? ValorPagado { get; set; }

    }
}
