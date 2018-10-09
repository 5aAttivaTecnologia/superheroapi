using API.SuperHeroes.Domain.Events;
using API.SuperHeroes.Domain.Interfaces;
using System.Collections.Generic;

namespace API.SuperHeroes.Domain.Handlers
{
    public class DomainNotificationHandler : IHandler<DomainNotification>
    {
        List<DomainNotification> _notificacoes;

        public DomainNotificationHandler()
        {
            _notificacoes = new List<DomainNotification>();
        }

        public void Dispose()
        {
            this._notificacoes = null;
        }

        public bool ExistemNotificacoes()
        {
            return _notificacoes.Count > 0;
        }

        public void Handle(DomainNotification args)
        {
            _notificacoes.Add(args);
        }

        public IEnumerable<DomainNotification> Notificar()
        {
            return ObterValores();
        }

        public List<DomainNotification> ObterValores()
        {
            return _notificacoes;
        }
    }
}

