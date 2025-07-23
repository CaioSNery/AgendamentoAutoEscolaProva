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


        public async Task<object> AddAlunoAsync(Alunos alunos)
        {
            _context.Alunos.Add(alunos);
            await _context.SaveChangesAsync();
            return alunos;
        }

        public async Task<object> AtualizarAlunoAsync(int id, Alunos alunoupdate)
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

        public async Task<IEnumerable<Alunos>> ListarAlunos()
        {
            return await _context.Alunos.AsNoTracking().ToListAsync();
        }
    }
}