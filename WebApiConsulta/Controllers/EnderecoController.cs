using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WebApiConsulta.Repository.Model;
using WebApiConsulta.Service.Interfaces;

namespace WebApiConsulta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecolService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecolService = enderecoService;
        }

        [HttpGet("listaEndereco")]
        public async ValueTask<IActionResult> BuscarEndereco()
        {
            try
            {
                var endereco = await _enderecolService.ListarEndereco();
                return endereco.Any() ? Ok(endereco) : BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao efetuar a pesquisa. {ex.Message}");
            }
        }

        [HttpPost("criarEndereco")]
        public async ValueTask<IActionResult> CriarEndereco([FromBody]Endereco endereco)
        {
            try
            {
                var enderecos = await _enderecolService.InserirEndereco(endereco);
                return endereco != null ? Ok(endereco) : BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao efetuar a pesquisa. {ex.Message}");
            }
        }

        [HttpPut("atualizarEndereco")]
        public async ValueTask<IActionResult> AtualizarEndereco([FromBody]EnderecoDto endereco)
        {
            try
            {
                var enderecos = await _enderecolService.AlterarEndereco(endereco);
                return enderecos != null ? Ok(enderecos) : BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao efetuar a pesquisa. {ex.Message}");
            }

        }

        [HttpDelete("deletarEndereco")]
        public async ValueTask<IActionResult> DeletarEndereco(int id)
        {
            try
            {                
                var endereco = await _enderecolService.ExcluirEndereco(id);
                return endereco != null ? Ok(endereco) : BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao efetuar o delete. {ex.Message}");
            }
        }
    }
}

