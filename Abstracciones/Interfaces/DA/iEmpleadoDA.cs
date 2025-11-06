
using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IEmpleadoDA
    {
        Task<IEnumerable<EmpleadoResponse>> Obtener();
        Task<EmpleadoResponse> Obtener(Guid Id);
        Task<Guid> Agregar(EmpleadoRequest empleado);
        Task<Guid> Editar(Guid Id, EmpleadoRequest empleado);
        Task<Guid> Eliminar(Guid Id);

    }
}
