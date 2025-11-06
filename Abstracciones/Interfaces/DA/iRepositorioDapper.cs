using Microsoft.Data.SqlClient;

namespace Abstracciones.Interfaces.DA
{
    public interface iRepositorioDapper
    {

        SqlConnection ObtenerRepositorio();
    }
}
