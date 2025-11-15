using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;

namespace Flujo
{
    public class EmpleadoFlujo : IEmpleadoFlujo
    {
        private readonly IEmpleadoDA _empleadoDA;

        public EmpleadoFlujo(IEmpleadoDA empleadoDA)
        {
            _empleadoDA = empleadoDA;
        }

        public Task<IEnumerable<EmpleadoResponse>> Obtener()
        {
            return _empleadoDA.Obtener();
        }

        public Task<EmpleadoResponse> Obtener(Guid Id)
        {
            return _empleadoDA.Obtener(Id);
        }

        public Task<Guid> Agregar(EmpleadoRequest empleado)
        {
            return _empleadoDA.Agregar(empleado);
        }

        public Task<Guid> Editar(Guid Id, EmpleadoRequest empleado)
        {
            return _empleadoDA.Editar(Id, empleado);
        }

        public Task<Guid> Eliminar(Guid Id)
        {
            return _empleadoDA.Eliminar(Id);
        }
    }
}
