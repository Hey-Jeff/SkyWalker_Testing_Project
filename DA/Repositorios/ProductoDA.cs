using System.Data;
using Microsoft.Data.SqlClient;
using Abstracciones.Interfaces.DA;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Dapper;
using Abstracciones.Modelos;

namespace DA.Repositorios
{
    public class ProductoDA : IProductoDA
    {
        private iRepositorioDapper _irepositorioDapper;
        private readonly SqlConnection _sqlConnection;

        #region Constructor
        [Obsolete]
        public ProductoDA(iRepositorioDapper irepositorioDapper)
        {
            _irepositorioDapper = irepositorioDapper;
            _sqlConnection = _irepositorioDapper.ObtenerRepositorio();
        }

        #endregion

        #region Operaciones
        public async Task<IEnumerable<ProductoResponse>> Obtener()
        {
            string query = @"ObtenerProductos";
            var resultadoConsulta = await _sqlConnection.QueryAsync<ProductoResponse>(query,
                commandType: CommandType.StoredProcedure);


            return resultadoConsulta;
        }

        public async Task<ProductoResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerProducto";
            var resultadoConsulta = await _sqlConnection.QueryAsync<ProductoResponse>(query, new { Id = Id }
            , commandType: CommandType.StoredProcedure);

            return resultadoConsulta.FirstOrDefault();
        }

        public async Task<Guid> Agregar(ProductoRequest producto)
        {
            string query = @"AgregarProducto";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                IdSubCategoria = producto.IdSubCategoria,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Stock = producto.StockActual,


            }, commandType: CommandType.StoredProcedure);

            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, ProductoRequest producto)
        {
            string query = @"EditarVehiculo";
            await VerificarProductoExiste(Id);

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                IdSubCategoria = producto.IdSubCategoria,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Stock = producto.StockActual,

            }, commandType: CommandType.StoredProcedure);

            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await VerificarProductoExiste(Id);
            string query = @"EliminarProducto";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                id = Id
            }, commandType: CommandType.StoredProcedure);

            return resultadoConsulta;
        }

        private async Task VerificarProductoExiste(Guid id)
        {
            ProductoResponse? resultadoConsultaProducto = await Obtener(id);

            if (resultadoConsultaProducto == null)

                throw new Exception("No se encontro el Producto");
        }
    }
    #endregion
}