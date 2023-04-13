using WebApiConsulta.Repository.Model;

namespace WebApiConsulta.Service.Interfaces
{
    public interface ITelefoneService
    {
        ValueTask<IEnumerable<Telefone>> ListarTelefone(int id);
    }
}
