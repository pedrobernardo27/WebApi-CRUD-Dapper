using WebApiConsulta.Repository.Model;

namespace WebApiConsulta.Repository.Interfaces
{
    public interface IEmailRepository
    {
        ValueTask<IEnumerable<Email>> Listar(string nome);
    }
}
