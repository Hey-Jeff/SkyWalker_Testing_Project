using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Abstracciones.Interfaces.DA;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Dapper;
using Abstracciones.Modelos;


namespace DA.Repositorios
{
     public class UsuarioDA : IUsuarioDA
    {
            private iRepositorioDapper _irepositorioDapper;
            private readonly SqlConnection _sqlConnection;

            #region Constructor
            [Obsolete]
            public UsuarioDA(iRepositorioDapper irepositorioDapper)
            {
                _irepositorioDapper = irepositorioDapper;
                _sqlConnection = _irepositorioDapper.ObtenerRepositorio();
            }

            #endregion

            #region Operaciones
            public async Task<IEnumerable<UsuarioResponse>> Obtener()
            {
                string query = @"ObtenerUsuarios";
                var resultadoConsulta = await _sqlConnection.QueryAsync<UsuarioResponse>(query,
                    commandType: CommandType.StoredProcedure);


                return resultadoConsulta;
            }

            public async Task<UsuarioResponse> Obtener(Guid Id)
            {
                string query = @"ObtenerUsuario";
                var resultadoConsulta = await _sqlConnection.QueryAsync<UsuarioResponse>(query, new { Id = Id }
                , commandType: CommandType.StoredProcedure);

                return resultadoConsulta.FirstOrDefault();
            }

            public async Task<Guid> Agregar(UsuarioRequest usuario)
            {
                string query = @"AgregarUsuario";
                var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
                {
                    IdUsuario = Guid.NewGuid(),
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Email = usuario.Email,
                    Telefono = usuario.Telefono,
                    PasswordHash = usuario.PasswordHash,
                    Rol = usuario.Rol
                }, commandType: CommandType.StoredProcedure);

            return resultadoConsulta;
            }

            public async Task<Guid> Editar(Guid Id, UsuarioRequest usuario)
            {
                string query = @"EditarUsuario";
                await VerificarUsuarioExiste(Id);

                var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
                {
                    IdUsuario = Guid.NewGuid(),
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Email = usuario.Email,
                    Telefono = usuario.Telefono,
                    PasswordHash = usuario.PasswordHash,
                    Rol = usuario.Rol
                }, commandType: CommandType.StoredProcedure);

            return resultadoConsulta;
            }

            public async Task<Guid> Eliminar(Guid Id)
            {
                await VerificarUsuarioExiste(Id);
                string query = @"EliminarUsuario";
                var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
                {
                    id = Id
                }, commandType: CommandType.StoredProcedure);

                return resultadoConsulta;
            }

            private async Task VerificarUsuarioExiste(Guid id)
            {
                UsuarioResponse? resultadoConsultaUsuario = await Obtener(id);

                if (resultadoConsultaUsuario == null)

                    throw new Exception("No se encontro el usuario");
            }
        }
    }
    #endregion

