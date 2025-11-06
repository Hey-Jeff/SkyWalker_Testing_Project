using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IEmpleadoFlujo
    {
        Task<IEnumerable<EmpleadoResponse>> Obtener();
        Task<EmpleadoResponse> Obtener(Guid Id);
        Task<Guid> Agregar(EmpleadoRequest empleado);
        Task<Guid> Editar(Guid Id, EmpleadoRequest empleado);
        Task<Guid> Eliminar(Guid Id);
    }
}
