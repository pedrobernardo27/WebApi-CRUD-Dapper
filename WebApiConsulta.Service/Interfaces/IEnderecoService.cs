using WebApiConsulta.Repository.Model;

namespace WebApiConsulta.Service.Interfaces
{
    public interface IEnderecoService
    {
        ValueTask<String> ExcluirEndereco(int id);
        ValueTask<Endereco> AlterarEndereco(EnderecoDto endereco);
        ValueTask<IEnumerable<Endereco>> ListarEndereco();
        ValueTask<Endereco> InserirEndereco(Endereco endereco);
    }
}
