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
        Task<object> AddAlunoAsync(Alunos alunos);

        Task<bool> DeletarAlunoAsync(int id);

        Task<IEnumerable<Alunos>> ListarAlunos();

        Task<object> BuscarAlunoPorIdAsync(int id);

        Task<object> AtualizarAlunoAsync(int id, Alunos alunoupdate);
    }
}