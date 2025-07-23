using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Data;
using Agendamento.Interfaces;
using Agendamento.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Agendamento.Services
{
    public class AgendamentoService : IAgendamentoService
    {

        private readonly AppDbContext _appDbContext;
        private readonly ISmSService _service;
        public AgendamentoService(AppDbContext appDbContext, ISmSService service)
        {
            _appDbContext = appDbContext;
            _service = service;
        }


        public async Task<object> CriarAsync(AgendaDTO dto)
        {

            var aluno = await _appDbContext.Alunos.FirstOrDefaultAsync(a=>a.Cpf==dto.AlunoCpf);


            if (aluno==null)
            {
                return "Aluno não encontrado no bando de dados";
            }

            var diadeprova = new DiaDaProva
            {
                DataProva = dto.DiaProva,
                AlunoId=aluno.Id               
            };

            _appDbContext.DiaDaProva.Add(diadeprova);

            await _appDbContext.SaveChangesAsync();

           
            
            string msg = $"Olá {aluno.Nome}, o dia da sua prova esta agendada para {dto.DiaProva} , por favor compareça com  10 minutos de antecedencia , Boa Sorte !!";
            await _service.EnviarSmSAsync(aluno.Telefone, msg);
            

            return new AgendaDTO
            {
                AlunoCpf = aluno.Cpf, 
                DiaProva = diadeprova.DataProva
            };
        }

        public async Task<DiaDaProva> ObterDiaProva(int id)
        {
            var aluno = await _appDbContext.Alunos.FirstOrDefaultAsync(a => a.Id == id);

            var diaProva = await _appDbContext.DiaDaProva.FirstOrDefaultAsync(d => d.Id == aluno.Id);

            return diaProva;

        }

        public async Task<IEnumerable<DiaDaProva>> ObterDiasDeProvaAsync()
        {
            return await _appDbContext.DiaDaProva.Include(d => d.DataProva).ToListAsync();
        }
    }
}