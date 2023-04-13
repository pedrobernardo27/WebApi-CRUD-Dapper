using Microsoft.Extensions.Logging;
using WebApiConsulta.Repository.Model;
using WebApiConsulta.Service.Interfaces;
using WebApiConsulta.Repository.Interfaces;

namespace WebApiConsulta.Service.Services
{
    public class TelefoneService : ITelefoneService
    {
        private readonly ILogger<TelefoneService> _logger;
        private readonly ITelefoneRepository _telefoneRepository;

        public TelefoneService(ILogger<TelefoneService> logger, ITelefoneRepository telefoneRepository)
        {
            _logger = logger;
            _telefoneRepository = telefoneRepository;
        }

        public async ValueTask<IEnumerable<Telefone>> ListarTelefone(int id)
        {
            try
            {
                _logger.LogInformation("Inicio do método ListarTelefone");

                var lstTelefone = new List<Telefone>();
                var resultTelefone = await _telefoneRepository.Listar(id);

                if (resultTelefone.Count() > 0)
                {
                    lstTelefone = (List<Telefone>)resultTelefone;
                }

                _logger.LogInformation("Fim do método ListarTelefone");

                return lstTelefone;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao efetuar ListarTelefone. {ex.Message}");
                throw new Exception($"Erro ao efetuar ListarTelefone. {ex.Message}");
            }
            
        }
    }
}
