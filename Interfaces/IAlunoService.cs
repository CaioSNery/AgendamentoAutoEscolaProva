using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Interfaces
{
    public interface IAlunoService
    {
        Task<object> AddAlunoAsync(Aluno alunos);

        Task<bool> DeletarAlunoAsync(int id);

        Task<IEnumerable<Aluno>> ListarAlunos();

        Task<object> BuscarAlunoPorIdAsync(int id);

        Task<object> AtualizarAlunoAsync(int id, Aluno alunoupdate);
    }
}