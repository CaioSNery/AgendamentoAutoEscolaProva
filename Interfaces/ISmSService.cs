using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Interfaces
{
    public interface ISmSService
    {
        Task EnviarSmSAsync(string numero, string mensagem);
    }
}