using WebApiConsulta.Repository.Model;

namespace WebApiConsulta.Repository.Interfaces
{
    public interface IEnderecoRepository
    {
        ValueTask<Endereco> Excluir(Endereco endereco);
        ValueTask<Endereco> ObterPorId(int id);
        ValueTask<IEnumerable<Endereco>> Listar();
        ValueTask<Endereco> Inserir(Endereco endereco);
        ValueTask<Endereco> Atualizar(Endereco endereco);

    }
}
