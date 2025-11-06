using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class ProductoBase
    {
        public int IdProducto { get; set; }
        public string ?Nombre { get; set; } 
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? Categoria { get; set; }
        public int StockActual { get; set; }

    }
        public class ProductoRequest : ProductoBase
    {
            public Guid IdSubCategoria { get; set; }
        }

        public class ProductoResponse : ProductoBase
        {
            public Guid Id { get; set; }
            public string SubCategoria { get; set; }
            public string Categoria { get; set; }
        }
    }
