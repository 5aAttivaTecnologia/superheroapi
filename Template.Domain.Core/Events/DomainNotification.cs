using System;
using System.Collections.Generic;
using System.Text;
using Template.Core.Domain.Interfaces;

namespace Template.Core.Domain.Events
{
    public sealed class DomainNotification: IDomainEvent
    {
        public string Chave { get; private set; }
        public string Valor { get; private set; }
        public DateTime DataOcorrencia { get; private set; }

        public DomainNotification(string chave, string valor)
        {
            Chave = chave;
            Valor = valor;
        }
    }
}
