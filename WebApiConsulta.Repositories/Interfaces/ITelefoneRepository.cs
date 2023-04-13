using WebApiConsulta.Repository.Model;

namespace WebApiConsulta.Repository.Interfaces
{
    public interface ITelefoneRepository
    {
        ValueTask<IEnumerable<Telefone>> Listar(int id);
    }
}
