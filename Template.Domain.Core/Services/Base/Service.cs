using System;
using System.Linq;
using Template.Core.Domain.Entities.Base;
using Template.Core.Domain.Events;
using Template.Core.Domain.Handlers;
using Template.Core.Domain.Interfaces;
using Template.Core.Infra.Data.Interfaces.UoW;

namespace Template.Core.Domain.Services.Base
{
    public abstract class Service<T>
    {
        DomainNotificationHandler _domainNotification;
        IUnitOfWork _unitOfWork;

        public Service(IHandler<DomainNotification> domainNotification, IUnitOfWork unitOfWork)
        {
            _domainNotification = (DomainNotificationHandler)domainNotification;
            _unitOfWork = unitOfWork;
        }

        protected bool VerificarEntidade(Entidade<T> entidade)
        {
            if (entidade.Validar()) return true;

            var notificacoes = entidade.ObterNotificacoes();

            if (!notificacoes.Any()) return true;

            notificacoes.ToList().ForEach(DomainEvent.Raise);

            return false;
        }

        public void Notificar(DomainNotification notification)
        {
            DomainEvent.Raise(notification);
        }

        protected bool Commit(string mensagemErroCommit)
        {
            if (_domainNotification.ExistemNotificacoes())
                return false;

            try
            {
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                DomainEvent.Raise(new DomainNotification("Erro", mensagemErroCommit));

                //log

                return false;
            }

            return true;
        }
    }
}
