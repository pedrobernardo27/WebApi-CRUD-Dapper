using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WebApiConsulta.Service.Interfaces;

namespace WebApiConsulta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class TelefoneController : Controller
    {
        private readonly ITelefoneService _telefoneService;

        public TelefoneController(ITelefoneService telefoneservice)
        {
            _telefoneService = telefoneservice;
        }

        [HttpGet("listaTelefone")]
        public async ValueTask<IActionResult> BuscarTelefone(int id)
        {
            try
            {
                var telefone = await _telefoneService.ListarTelefone(id);
                return telefone.Any() ? Ok(telefone) : BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao efetuar a pesquisa. {ex.Message}");
            }
        }
    }
}
