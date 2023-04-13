using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApiConsulta.Repositorie.Connection;

public sealed class SqlServerConnection : ISqlServerConnection
{
    private readonly SqlConnection _connection;
    public SqlConnection Connection => _connection;

    public SqlServerConnection()
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();

        _connection = new SqlConnection(config.GetConnectionString("StrConnection"));
    }

    public void Dispose() => _connection?.Dispose();
}