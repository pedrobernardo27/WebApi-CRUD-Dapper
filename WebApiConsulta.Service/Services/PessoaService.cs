using Microsoft.Extensions.Logging;
using WebApiConsulta.Repositorie.Model;
using WebApiConsulta.Service.Interfaces;
using WebApiConsulta.Repositorie.Interfaces;

namespace WebApiConsulta.Service.Servicess
{
    public class PessoaService : IPessoaService
    {
        private readonly ILogger<PessoaService> _logger;
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(ILogger<PessoaService> logger, IPessoaRepository pessoaRepository)
        {
            _logger = logger;
            _pessoaRepository = pessoaRepository;
        }

        public async ValueTask<IEnumerable<Pessoa>> ListarPessoas()
        {
            try
            {
                _logger.LogInformation("Inicio do método ListarPessoas");

                var lstPessoas = new List<Pessoa>();
                var resultPessoa = await _pessoaRepository.Listar();

                if (resultPessoa.Count() > 0)
                {
                    lstPessoas = (List<Pessoa>)resultPessoa;
                }

                _logger.LogInformation("Fim do método ListarPessoas");

                return lstPessoas;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao efetuar ListarPessoas {ex.Message}");
                throw new Exception($"Erro ao efetuar ListarPessoas {ex.Message}");
            }            
        }

        public async ValueTask<Pessoa> InserirPessoas(Pessoa pessoa)
        {
            try
            {
                _logger.LogInformation("Inicio do método InserirPessoas");

                var pessoas = new Pessoa();
                var resultPessoa = await _pessoaRepository.Inserir(pessoa);

                if (resultPessoa != null)
                {
                    pessoas = (Pessoa)resultPessoa;
                }

                _logger.LogInformation("Fim do método InserirPessoas");

                return pessoas;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}

