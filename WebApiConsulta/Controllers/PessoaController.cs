using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WebApiConsulta.Repositorie.Model;
using WebApiConsulta.Service.Interfaces;

namespace WebApiConsulta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet("listaPessoa")]
        public async ValueTask<IActionResult> BuscarPessoa()
        {
            try
            {
                var pessoas = await _pessoaService.ListarPessoas();
                return pessoas.Any() ? Ok(pessoas) : BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao efetuar a pesquisa. {ex.Message}");
            }            
        }

        [HttpPost("criarPessoa")]
        public async ValueTask<IActionResult> CriarPessoas([FromBody] Pessoa pessoa)
        {
            try
            {
                var pessoas = await _pessoaService.InserirPessoas(pessoa);
                return pessoas != null ? Ok(pessoas) : BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao efetuar a pesquisa. {ex.Message}");
            }
        }
    }
}
