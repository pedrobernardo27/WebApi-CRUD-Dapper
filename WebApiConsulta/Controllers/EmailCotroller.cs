using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WebApiConsulta.Service.Interfaces;

namespace WebApiConsulta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet("listaEmail")]
        public async ValueTask<IActionResult> BuscarEmail(string nome)
        {
            try
            {
                var email = await _emailService.ListarEmail(nome);
                return email.Any() ? Ok(email) : BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao efetuar a pesquisa. {ex.Message}");
            }
        }

    }
}
