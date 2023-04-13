using Microsoft.Extensions.Logging;
using WebApiConsulta.Repository.Model;
using WebApiConsulta.Service.Interfaces;
using WebApiConsulta.Repository.Interfaces;

namespace WebApiConsulta.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IEmailRepository _emailRepository;

        public EmailService(ILogger<EmailService> logger, IEmailRepository emailRepository)
        {
            _logger = logger;
            _emailRepository = emailRepository;
        }

        public async ValueTask<IEnumerable<Email>> ListarEmail(string nome)
        {
            try
            {
                _logger.LogInformation("Inicio do método ListarEmail");

                var lstEmail = new List<Email>();
                var resultEmail = await _emailRepository.Listar(nome);

                if (resultEmail.Count() > 0)
                {
                    lstEmail = (List<Email>)resultEmail;
                }

                _logger.LogInformation("Fim do método ListarEmail");

                return lstEmail;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao efetuar ListarEmail. {ex.Message}");
                throw new Exception($"Erro ao efetuar ListarEmail. {ex.Message}");
            }            
        }
    }
}
