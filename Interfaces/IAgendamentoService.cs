using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Models;

namespace Agendamento.Interfaces
{
    public interface IAgendamentoService
    {
        Task<object> CriarAsync(AgendaDTO dto);

        Task<IEnumerable<DiaDaProva>> ObterDiasDeProvaAsync();

        Task<DiaDaProva> ObterDiaProva(int id);
    }
}