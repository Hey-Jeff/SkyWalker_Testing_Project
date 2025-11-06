using System.Data;
using Microsoft.Data.SqlClient;
using Abstracciones.Interfaces.DA;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Dapper;
using Abstracciones.Modelos;

namespace DA.Repositorios
{
    public class EmpleadoDA : IEmpleadoDA
    {

        private iRepositorioDapper _irepositorioDapper;
        private readonly SqlConnection _sqlConnection;

        #region Constructor
        [Obsolete]
        public EmpleadoDA(iRepositorioDapper irepositorioDapper)
        {
            _irepositorioDapper = irepositorioDapper;
            _sqlConnection = _irepositorioDapper.ObtenerRepositorio();
        }

        #endregion

        #region Operaciones
        public async Task<IEnumerable<EmpleadoResponse>> Obtener()
        {
            string query = @"ObtenerEmpleados";
            var resultadoConsulta = await _sqlConnection.QueryAsync<EmpleadoResponse>(query,
                commandType: CommandType.StoredProcedure);


            return resultadoConsulta;
        }

        public async Task<EmpleadoResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerEmpleado";
            var resultadoConsulta = await _sqlConnection.QueryAsync<EmpleadoResponse>(query, new { Id = Id }
            , commandType: CommandType.StoredProcedure);

            return resultadoConsulta.FirstOrDefault();
        }

        public async Task<Guid> Agregar(EmpleadoRequest empleado)
        {
            string query = @"AgregarEmpleado";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdEmpleado = Guid.NewGuid(),
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                Puesto = empleado.Puesto,
                Contacto = empleado.Contacto,
                FechaIngreso = empleado.FechaIngreso


            }, commandType: CommandType.StoredProcedure);

            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, EmpleadoRequest empleado)
        {
            string query = @"EditarEmpleado";
            await VerificarempleadoExiste(Id);

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdEmpleado = Guid.NewGuid(),
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                Puesto = empleado.Puesto,
                Contacto = empleado.Contacto,
                FechaIngreso = empleado.FechaIngreso

            }, commandType: CommandType.StoredProcedure);

            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await VerificarempleadoExiste(Id);
            string query = @"Eliminarempleado";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                id = Id
            }, commandType: CommandType.StoredProcedure);

            return resultadoConsulta;
        }

        private async Task VerificarempleadoExiste(Guid id)
        {
            EmpleadoResponse? resultadoConsultaempleado = await Obtener(id);

            if (resultadoConsultaempleado == null)

                throw new Exception("No se encontro el Empleado");
        }
    }
    #endregion
}


