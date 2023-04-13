using Microsoft.Extensions.Logging;
using WebApiConsulta.Repository.Model;
using WebApiConsulta.Service.Interfaces;
using WebApiConsulta.Repository.Interfaces;

namespace WebApiConsulta.Service.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly ILogger<EnderecoService> _logger;
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(ILogger<EnderecoService> logger, IEnderecoRepository enderecoRepository)
        {
            _logger = logger;
            _enderecoRepository = enderecoRepository;
        }

        public async ValueTask<IEnumerable<Endereco>> ListarEndereco()
        {
            try
            {
                _logger.LogInformation("Inicio do método ListarEndereco");

                var lstEndereco = new List<Endereco>();
                var resultEndereco = await _enderecoRepository.Listar();

                if (resultEndereco.Count() > 0)
                {
                    lstEndereco = (List<Endereco>)resultEndereco;
                }

                _logger.LogInformation("Fim do método ListarEndereco");

                return lstEndereco;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao efetuar ListarEndereço. {ex.Message}");
                throw new Exception($"Erro ao efetuar listar endereço. {ex.Message}");
            }            
        }
        public async ValueTask<Endereco> InserirEndereco(Endereco endereco)
        {
            try
            {
                _logger.LogInformation("Inicio do método InserirEndereco");

                var enderecos = new Endereco();
                var resultEndereco = await _enderecoRepository.Inserir(endereco);

                if (resultEndereco != null)
                {
                    enderecos = (Endereco)resultEndereco;
                }

                _logger.LogInformation("Fim do método InserirEndereco");

                return enderecos;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao afetuar InserirEndereco. {ex.Message}");
                throw new Exception($"Erro ao afetuar InserirEndereco. {ex.Message}");
            }            
        }

        public async ValueTask<Endereco> AlterarEndereco(EnderecoDto endereco)
        {
            try
            {
                _logger.LogInformation("Inicio do método AlterarEndereco");

                var enderecoResult = new Endereco();
                var enderecoValidado = await _enderecoRepository.ObterPorId(endereco.Id);                

                if (enderecoValidado != null)
                {
                    enderecoValidado.Id = endereco.Id;
                    enderecoValidado.Rua = endereco.Rua;
                    enderecoValidado.Bairro = endereco.Bairro;
                    enderecoValidado.Cidade = endereco.Cidade;

                    var resultEndereco = await _enderecoRepository.Atualizar(enderecoValidado);

                    if (resultEndereco != null)
                    {
                        enderecoResult = resultEndereco;
                    }                    
                }

                _logger.LogInformation("Fim do método AlterarEndereco");

                return enderecoResult;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao efetuar AlterarEndereco. {ex.Message}");
                throw new Exception($"Erro ao efetuar AlterarEndereco. {ex.Message}");
            }            
        }

        public async ValueTask<String> ExcluirEndereco(int id)
        {
            try
            {
                _logger.LogInformation("Inicio do método ExcluirEndereco");

                var mensagem = $"Id {id} não existe na tabela Endereço";
                var enderecoValidado = await _enderecoRepository.ObterPorId(id);

                if(enderecoValidado != null)
                {                    
                    var resultEndereco = await _enderecoRepository.Excluir(enderecoValidado);

                    if (resultEndereco != null)
                    {
                        mensagem = "Deletado com sucesso.";
                    }
                }               

                _logger.LogInformation("Fim do método ExcluirEndereco");

                return mensagem;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao efetuar ExcluirEndereco. {ex.Message}");
                throw new Exception($"Erro ao efetuar ExcluirEndereco. {ex.Message}");
            }            
        }
    }
}
