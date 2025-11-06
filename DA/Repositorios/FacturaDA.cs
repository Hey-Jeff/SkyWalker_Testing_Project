using System.Data;
using Microsoft.Data.SqlClient;
using Abstracciones.Interfaces.DA;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Dapper;
using Abstracciones.Modelos;

namespace DA.Repositorios
{
    public class FacturaDA : IFacturaDA

    {
        private iRepositorioDapper _irepositorioDapper;
        private readonly SqlConnection _sqlConnection;

        #region Constructor
        [Obsolete]
        public FacturaDA(iRepositorioDapper irepositorioDapper)
        {
            _irepositorioDapper = irepositorioDapper;
            _sqlConnection = _irepositorioDapper.ObtenerRepositorio();
        }
        #endregion


        public async Task<Guid> Agregar(FacturaRequest factura)
        {
            string query = @"CrearFacturaConDetalles";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
              


            }, commandType: CommandType.StoredProcedure);

            return resultadoConsulta;
        }

        public async Task<IEnumerable<FacturaResponse>> Obtener()
        {
            string query = @"ObtenerFacturasConDetalle";
            var resultadoConsulta = await _sqlConnection.QueryAsync<FacturaResponse>(query,
                commandType: CommandType.StoredProcedure);


            return resultadoConsulta;
        }



}
}
