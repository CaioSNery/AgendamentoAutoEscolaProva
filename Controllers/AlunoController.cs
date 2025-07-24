using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Data;
using Agendamento.Interfaces;
using Agendamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agendamento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _service;
        public AlunoController(IAlunoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddAlunos([FromBody] Aluno alunos)
        {
            var resultado = await _service.AddAlunoAsync(alunos);
            return Ok(new AlunoDTO
        {
           Id = alunos.Id,
           Nome = alunos.Nome,
           Cpf = alunos.Cpf,
           Telefone = alunos.Telefone,
           Renach = alunos.Renach
        });
        }

        [HttpGet]
        public async Task<IActionResult> ListarALunos()
        {
            var alunos = await _service.ListarAlunos();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarAluno(int id)
        {
            var aluno = await _service.BuscarAlunoPorIdAsync(id);
            if (aluno == null) return NotFound();

            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAluno(int id, [FromBody] Aluno alunosupdate)
        {
            
            var resultado= await _service.AtualizarAlunoAsync(id,alunosupdate);
            if (resultado == null) return NotFound();

            return Ok(resultado);
            

            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAluno(int id)
        {
            var resultado = await _service.DeletarAlunoAsync(id);
            return Ok(resultado);
        }

    }
}