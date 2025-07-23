using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Models
{
    public class DiaDaProva
    {
        public int Id { get; set; }

        public int AlunoId { get; set; }
        public DateTime DataProva { get; set; }
        
        public Alunos Alunos{ get; set; }
    }
}