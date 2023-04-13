using Dapper;
using System.Data;
using WebApiConsulta.Repository.Model;
using WebApiConsulta.Repository.Interfaces;
using WebApiConsulta.Repositorie.Connection;

namespace WebApiConsulta.Repository.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        public async ValueTask<IEnumerable<Telefone>> Listar(int id)
        {
            var lstTelefone = new List<Telefone>();
            var sqlServerConnection = new SqlServerConnection();

            if (sqlServerConnection.Connection != null)
            {
                using var multi = await sqlServerConnection.Connection.QueryMultipleAsync(sql: "proc_BuscarTelefone",
                    param: new { id }, commandType: CommandType.StoredProcedure);

                var resultTelefone = await multi.ReadAsync<Telefone>();

                if (resultTelefone.Count() > 0)
                {
                    foreach (var telefone in resultTelefone)
                    {
                        lstTelefone.Add(telefone);
                    }
                }
            }

            return lstTelefone;
        }
    }
}
