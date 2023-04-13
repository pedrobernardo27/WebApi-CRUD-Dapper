using Dapper;
using System.Data;
using WebApiConsulta.Repository.Model;
using WebApiConsulta.Repository.Interfaces;
using WebApiConsulta.Repositorie.Connection;

namespace WebApiConsulta.Repository.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        public async ValueTask<IEnumerable<Email>> Listar(string nome)
        {
            var lstEmail = new List<Email>();
            var sqlServerConnection = new SqlServerConnection();

            if (sqlServerConnection.Connection != null)
            {
                using var multi = await sqlServerConnection.Connection.QueryMultipleAsync(sql: "proc_BuscarEmail",
                    param: new { nome }, commandType: CommandType.StoredProcedure);

                var resultEmail = await multi.ReadAsync<Email>();

                if (resultEmail.Count() > 0)
                {
                    foreach (var email in resultEmail)
                    {
                        lstEmail.Add(email);
                    }
                }
            }

            return lstEmail;
        }
    }
}
