using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class FacturaResponse
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }

    public class FacturaRequest
    {
        public int IdCarrito { get; set; }
        public int IdUsuario { get; set; }
        public int? IdEmpleado { get; set; }
        public string MetodoPago { get; set; }
        public List<FacturaResponse> Detalles { get; set; } = new();
    }
}
