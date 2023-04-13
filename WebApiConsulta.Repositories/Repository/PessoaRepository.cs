using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using WebApiConsulta.Repositorie.Model;
using WebApiConsulta.Repositorie.Connection;
using WebApiConsulta.Repositorie.Interfaces;

namespace WebApiConsulta.Repositorie.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        public async ValueTask<IEnumerable<Pessoa>> Listar()
        {
            var lstPessoa = new List<Pessoa>();
            var sqlServerConnection = new SqlServerConnection();

            if (sqlServerConnection.Connection != null)
            {
                lstPessoa = (List<Pessoa>)await sqlServerConnection.Connection.QueryAsync<Pessoa>("SELECT Id, Nome, Sobrenome, Idade, Cpf " +
                "FROM Pessoa", commandType: CommandType.Text).ConfigureAwait(false);
            }

            return lstPessoa;
        }

        public async ValueTask<Pessoa> Inserir(Pessoa pessoa)
        {
            var sqlServerConnection = new SqlServerConnection();
            
            using (IDbConnection db = new SqlConnection(sqlServerConnection.Connection.ConnectionString))
            {                
                var insertQuery = @"INSERT INTO [dbo].[Pessoa]([Nome], [Sobrenome], [Idade], [Cpf]) VALUES (@Nome, @Sobrenome, @Idade, @Cpf)";

                var result = await db.ExecuteAsync(insertQuery, new
                {
                    pessoa.Nome,
                    pessoa.Sobrenome,
                    pessoa.Idade,
                    pessoa.Cpf
                });
            }
            
            return pessoa;
        }
    }
}
