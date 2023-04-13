using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using WebApiConsulta.Repository.Model;
using WebApiConsulta.Repository.Interfaces;
using WebApiConsulta.Repositorie.Connection;

namespace WebApiConsulta.Repository.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        public async ValueTask<IEnumerable<Endereco>> Listar()
        {
            var lstEndereco = new List<Endereco>();
            var sqlServerConnection = new SqlServerConnection();

            if (sqlServerConnection.Connection != null)
            {
                using var multi = await sqlServerConnection.Connection.QueryMultipleAsync(sql: "proc_BuscarEndereco",
                    commandType: CommandType.StoredProcedure);

                var resultEndereco = await multi.ReadAsync<Endereco>();

                if (resultEndereco.Count() > 0)
                {
                    foreach (var endereco in resultEndereco)
                    {
                        lstEndereco.Add(endereco);
                    }
                }
            }

            return lstEndereco;
        }
        public async ValueTask<Endereco> Inserir(Endereco endereco)
        {
            var sqlServerConnection = new SqlServerConnection();

            if (sqlServerConnection.Connection != null)
            {
                using (IDbConnection db = new SqlConnection(sqlServerConnection.Connection.ConnectionString))
                {
                    var formParams = new DynamicParameters();
                    formParams.Add("@Rua", endereco.Rua);
                    formParams.Add("@Bairro", endereco.Bairro);
                    formParams.Add("@Cidade", endereco.Cidade);
                    formParams.Add("@Cep", endereco.Cep);
                    formParams.Add("@Id_Pessoa", endereco.Id_Pessoa);

                    var insertQuery = await db.ExecuteAsync("proc_CriarEndereco", formParams,
                        commandType: CommandType.StoredProcedure);
                }
            }

            return endereco;
        }

        public async ValueTask<Endereco> Atualizar(Endereco endereco)
        {
            var sqlServerConnection = new SqlServerConnection();

            if (sqlServerConnection.Connection != null)
            {
                using (IDbConnection db = new SqlConnection(sqlServerConnection.Connection.ConnectionString))
                {
                    var formParams = new DynamicParameters();
                    formParams.Add("@Id", endereco.Id);
                    formParams.Add("@Rua", endereco.Rua);
                    formParams.Add("@Bairro", endereco.Bairro);
                    formParams.Add("@Cidade", endereco.Cidade);
                    formParams.Add("@Cep", endereco.Cep);
                    formParams.Add("@Id_Pessoa", endereco.Id_Pessoa);

                    var insertQuery = await db.ExecuteAsync("proc_AtualizarEndereco", formParams,
                        commandType: CommandType.StoredProcedure);
                }
            }

            return endereco;
        }

        public async ValueTask<Endereco> Excluir(Endereco endereco)
        {
            var sqlServerConnection = new SqlServerConnection();

            if (sqlServerConnection.Connection != null)
            {
                using (IDbConnection db = new SqlConnection(sqlServerConnection.Connection.ConnectionString))
                {
                    var insertQuery = await db.ExecuteAsync("proc_DeletarEndereco",
                        param: new { endereco.Id }, commandType: CommandType.StoredProcedure);
                }
            }

            return endereco;
        }

        public async ValueTask<Endereco> ObterPorId(int id)
        {
            try
            {
                var sql = $"SELECT Id, Rua, Bairro, Cidade, Cep, Id_Pessoa FROM Endereco WHERE Id = {id}";
                var endereco = new Endereco();
                var sqlServerConnection = new SqlServerConnection();

                if (sqlServerConnection.Connection != null)
                {
                    endereco = await sqlServerConnection.Connection.QueryFirstOrDefaultAsync<Endereco>(sql);
                }

                return endereco;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            
        }
    }
}
            

           