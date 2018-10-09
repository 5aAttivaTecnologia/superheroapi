using API.SuperHeroes.Domain.Interfaces;
using System;

namespace API.SuperHeroes.Domain.Events
{
    public sealed class DomainNotification : IDomainEvent
    {
        public string Chave { get; private set; }
        public string Valor { get; private set; }
        public DateTime DataOcorrencia { get; private set; }

        public DomainNotification(string chave, string valor)
        {
            Chave = chave;
            Valor = valor;
            DataOcorrencia = DateTime.Now;
        }


        public static class DomainNotificationFactory
        {
            public static DomainNotification Criar(string chave, string valor)
            {
                return new DomainNotification(chave, valor);
            }

            public static DomainNotification Erro(string valor)
            {
                return Criar("Erro", valor);
            }
        }
    }
}
