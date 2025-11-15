using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Flujo;
using Microsoft.AspNetCore.Mvc;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase, iEmpleadoController
    {
        private IEmpleadoFlujo _empleadoFlujo;
        private ILogger<EmpleadoController> _logger;

        public EmpleadoController(IEmpleadoFlujo empleadoFlujo, ILogger<EmpleadoController> logger)
        {
            _empleadoFlujo = empleadoFlujo;
            _logger = logger;
        }

        #region Operaciones
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _empleadoFlujo.Obtener();

            if (!resultado.Any())

                return NoContent();

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(Guid id)
        {
            var resultado = await _empleadoFlujo.Obtener(id);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] EmpleadoRequest empleado)
        {
            var resultado = await _empleadoFlujo.Agregar(empleado);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(Guid id, [FromBody] EmpleadoRequest empleado)
        {
            if (!await VerificarempleadoExiste(id))
                return NotFound("el empleado no existe");
            var resultado = await _empleadoFlujo.Editar(id, empleado);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            if (!await VerificarempleadoExiste(id))
                return NotFound("el empleado no existe");

            var resultado = await _empleadoFlujo.Eliminar(id);
            return NoContent();
        }

        #endregion operaciones

        #region Helpers
        private async Task<bool> VerificarempleadoExiste(Guid id)
        {
            var ResultadoValidacion = false;
            var resultadoempleadoexiste = await _empleadoFlujo.Obtener(id);
            if (resultadoempleadoexiste != null)
                ResultadoValidacion = true;
            return ResultadoValidacion;
        }
        #endregion helpers
    }
}
