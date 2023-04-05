
using Microsoft.AspNetCore.Mvc;
using Vacinas.API.Controllers;
using Vacinas.API.Model;
using Vacinas.API.Repositories;

namespace Vacina.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacinaController : ControllerBase
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly ILogger<VacinaController> _logger;

        public VacinaController(ILogger<VacinaController> logger, IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<Relatorio> Get(string nome, string cpf, string data)
        {
            return await _consultaRepository.Get(nome, cpf, data);
        }

        [HttpGet("BuscarRelatorios")]
        public async Task<IEnumerable<Relatorio>> BuscarRelatorios()
        {
            return await _consultaRepository.GetRelatorios();
        }
    }
}
