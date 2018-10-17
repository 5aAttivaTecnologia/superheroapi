using API.SuperHeroes.Domain.Entidade.Base;
using API.SuperHeroes.Domain.Events;
using API.SuperHeroes.Domain.Handlers;
using API.SuperHeroes.Domain.Interfaces;
using API.SuperHeroes.Domain.Interfaces.Repositories;
using API.SuperHeroes.Domain.Interfaces.UoW;
using System;
using System.Linq;

namespace API.SuperHeroes.Domain.Service.Base
{
    public abstract class Service<T>
    {
        protected DomainNotificationHandler _domainNotification;
        protected IUnitOfWorkSuperheroes _unitOfWorkSuperheroes;
        private IHandler<DomainNotification> domainNotification;
        private IUnitOfWorkSuperheroes unitOfWorkSuperheroes;
        private IUsuarioRepository usuariorepository;

        protected Service(IHandler<DomainNotification> domainNotification, IUnitOfWorkSuperheroes unitOfWorkSuperheroes )
        {
            _domainNotification = (DomainNotificationHandler)domainNotification;
            _unitOfWorkSuperheroes = unitOfWorkSuperheroes;
        }

        protected Service(IHandler<DomainNotification> domainNotification, IUnitOfWorkSuperheroes unitOfWorkSuperheroes, IUsuarioRepository usuariorepository)
        {
            this.domainNotification = domainNotification;
            this.unitOfWorkSuperheroes = unitOfWorkSuperheroes;
            this.usuariorepository = usuariorepository;
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
                _unitOfWorkSuperheroes.Commit();
            }
            catch (Exception)
            {
                Notificar(DomainNotification.DomainNotificationFactory.Erro(mensagemErroCommit));
                //log

                return false;
            }

            return true;
        }
    }
}
