using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public required string Telefone { get; set; }
        public required string Renach { get; set; }

        public List<DiaDaProva>DiaDaProva{ get; set; }
        
    }
}