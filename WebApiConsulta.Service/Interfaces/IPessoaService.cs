using WebApiConsulta.Repositorie.Model;

namespace WebApiConsulta.Service.Interfaces
{
    public interface IPessoaService
    {
        ValueTask<IEnumerable<Pessoa>> ListarPessoas();
        ValueTask<Pessoa> InserirPessoas(Pessoa pessoa);
    }
}
