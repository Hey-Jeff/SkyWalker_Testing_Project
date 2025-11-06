using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Carrito
    {
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; } 
        public decimal Total { get; set; }
        public int IdUbicacion { get; set; }

    }


    public class CarritoRequest : Carrito
    {
        public Guid IdCarrito { get; set; }
        public int IdUsuario { get; set; }
    }

    public class ECarritoResponse : Carrito
    {
        public Guid IdCarrito { get; set; }
        public int IdUsuario { get; set; }

    }


}
