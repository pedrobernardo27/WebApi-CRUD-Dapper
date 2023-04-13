using WebApiConsulta.Repository.Model;

namespace WebApiConsulta.Service.Interfaces
{
    public interface IEmailService
    {
        ValueTask<IEnumerable<Email>> ListarEmail(string nome);
    }
}
