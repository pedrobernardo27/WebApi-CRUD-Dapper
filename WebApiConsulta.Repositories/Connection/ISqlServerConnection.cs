using Microsoft.Data.SqlClient;

namespace WebApiConsulta.Repositorie.Connection;

public interface ISqlServerConnection : IDisposable
{
    SqlConnection Connection { get; }
}
