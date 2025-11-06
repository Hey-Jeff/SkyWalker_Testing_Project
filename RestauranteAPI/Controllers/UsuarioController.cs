using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace RestauranteAPI.Controllers
{
   [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase, IUsuarioController
    {
        private IUsuarioFlujo _usuarioFlujo;
        private ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioFlujo usuarioFlujo, ILogger<UsuarioController> logger)
        {
            _usuarioFlujo = usuarioFlujo;
            _logger = logger;
        }

        #region Operaciones
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _usuarioFlujo.Obtener();

            if (!resultado.Any())

                return NoContent();

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(Guid id)
        {
            var resultado = await _usuarioFlujo.Obtener(id);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] UsuarioRequest Usuario)
        {
            var resultado = await _usuarioFlujo.Agregar(Usuario);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(Guid id, [FromBody] UsuarioRequest Usuario)
        {
            if (!await VerificarUsuarioExiste(id))
                return NotFound("el usuario no existe");
            var resultado = await _usuarioFlujo.Editar(id, Usuario);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            if (!await VerificarUsuarioExiste(id))
                return NotFound("el Usuario no existe");

            var resultado = await _usuarioFlujo.Eliminar(id);
            return NoContent();
        }

        #endregion operaciones

        #region Helpers
        private async Task<bool> VerificarUsuarioExiste(Guid id)
        {
            var ResultadoValidacion = false;
            var resultadousuarioexiste = await _usuarioFlujo.Obtener(id);
            if (resultadousuarioexiste != null)
                ResultadoValidacion = true;
            return ResultadoValidacion;
        }
        #endregion helpers
    }
}
