using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Interfaces;
using Agendamento.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoService _service;
        public AgendamentoController(IAgendamentoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<object> AgendarAluno([FromBody] AgendaDTO dto)
        {
            var agenda = await _service.CriarAsync(dto);

            if (agenda is string erro)
            {
                if (erro.Contains("não encontrado")) return NotFound(erro);
                return BadRequest(erro);
            }

            return Ok(agenda);

        }

        [HttpGet]
        public async Task<IActionResult> ListarDiasDeProva()
        {
            var agenda = await _service.ObterDiasDeProvaAsync();
            return Ok(agenda);

        }

        


    }
}