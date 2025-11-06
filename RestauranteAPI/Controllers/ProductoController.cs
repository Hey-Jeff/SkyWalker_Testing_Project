using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase, IProductoController
    {
        private IProductoFlujo _productoFlujo;
        private ILogger<ProductoController> _logger;

        public ProductoController(IProductoFlujo productoFlujo, ILogger<ProductoController> logger)
        {
            _productoFlujo = productoFlujo;
            _logger = logger;
        }

        #region Operaciones
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _productoFlujo.Obtener();

            if (!resultado.Any())

                return NoContent();

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(Guid id)
        {
            var resultado = await _productoFlujo.Obtener(id);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] ProductoRequest producto)
        {
            var resultado = await _productoFlujo.Agregar(producto);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(Guid id, [FromBody] ProductoRequest producto)
        {
            if (!await VerificarProductoExiste(id))
                return NotFound("el producto no existe");
            var resultado = await _productoFlujo.Editar(id, producto);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            if (!await VerificarProductoExiste(id))
                return NotFound("el producto no existe");

            var resultado = await _productoFlujo.Eliminar(id);
            return NoContent();
        }

        #endregion operaciones

        #region Helpers
        private async Task<bool> VerificarProductoExiste(Guid id)
        {
            var ResultadoValidacion = false;
            var resultadoproductoexiste = await _productoFlujo.Obtener(id);
            if (resultadoproductoexiste != null)
                ResultadoValidacion = true;
            return ResultadoValidacion;
        }
        #endregion helpers
    }
}
