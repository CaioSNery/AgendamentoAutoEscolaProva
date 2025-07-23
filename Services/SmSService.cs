using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Interfaces;
using Agendamento.Settings;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Agendamento.Services
{
    public class SmSService : ISmSService
    {
        
        private readonly TwilioSettings _settings;
        public SmSService(IOptions<TwilioSettings> options)
        {
            _settings = options.Value;
            TwilioClient.Init(_settings.AccountSID, _settings.AuthToken);
        }

        public async Task EnviarSmSAsync(string numero, string mensagem)
        {


            await MessageResource.CreateAsync(
                to: new PhoneNumber(numero),
                from: new PhoneNumber(_settings.From),
                body: mensagem
            );
        }
    }
}