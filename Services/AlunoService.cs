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
    public class AlunoService : IAlunoService
    {

        private readonly AppDbContext _context;
        public AlunoService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<object> AddAlunoAsync(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }

        public async Task<object> AtualizarAlunoAsync(int id, Aluno alunoupdate)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return false;

            aluno.Nome = alunoupdate.Nome;
            aluno.Cpf = alunoupdate.Cpf;
            aluno.Renach = alunoupdate.Renach;
            aluno.Telefone = alunoupdate.Telefone;

            await _context.SaveChangesAsync();

            return "Aluno atualizado com sucesso";
        }

        public async Task<object> BuscarAlunoPorIdAsync(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return false;

            return aluno;
        }

        public async Task<bool> DeletarAlunoAsync(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return false;

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return true;
                
        }

        public async Task<IEnumerable<Aluno>> ListarAlunos()
        {
            return await _context.Alunos.AsNoTracking().ToListAsync();
        }
    }
}