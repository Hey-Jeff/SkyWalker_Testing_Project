using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Empleadobase
    {

        public string Nombre { get; set; } 
        public string Apellido { get; set; }
        public string Puesto { get; set; } 
        public string Contacto { get; set; } 
        public DateTime FechaIngreso { get; set; }
    }

    public class EmpleadoRequest : Empleadobase
    {
        public Guid IdEmpleado { get; set; }
    }

    public class EmpleadoResponse : Empleadobase
    {
        public Guid IdEmpleado { get; set; }
        public string? Nombre { get; set; }
    }


}
