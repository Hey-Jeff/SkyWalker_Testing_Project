using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IFacturaController
    {
        Task<IActionResult> Agregar(FacturaRequest factura);

        // posible solucion Task<IActionResult> Agregar(int idCarrito, int idUsuario, int? idEmpleado, string metodoPago);
        Task<IActionResult> Obtener(Guid Id);
    }
}
    