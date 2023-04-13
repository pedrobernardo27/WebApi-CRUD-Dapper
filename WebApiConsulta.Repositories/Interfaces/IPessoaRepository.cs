using WebApiConsulta.Repositorie.Model;

namespace WebApiConsulta.Repositorie.Interfaces
{
    public interface IPessoaRepository
    {
        ValueTask<IEnumerable<Pessoa>> Listar();
        ValueTask<Pessoa> Inserir(Pessoa pessoa);
    }
}
