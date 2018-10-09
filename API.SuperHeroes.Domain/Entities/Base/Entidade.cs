using API.SuperHeroes.Domain.Entidade.Validacoes.Base;
using API.SuperHeroes.Domain.Events;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace API.SuperHeroes.Domain.Entidade.Base
{
    public abstract class Entidade<T>
    {
        readonly Validador<T> _validador;

        ValidationResult resultadoValidacao;

        protected Entidade(Validador<T> validador)
        {
            _validador = validador;
        }

        public abstract bool Validar();

        public bool Validar(T entidade)
        {
            _validador.ConfigurarValidacoes();

            resultadoValidacao = _validador.Validate(entidade);

            return resultadoValidacao.IsValid;
        }

        public List<DomainNotification> ObterNotificacoes()
        {
            return resultadoValidacao.Errors.Select(e => new DomainNotification(e.PropertyName, e.ErrorMessage)).ToList();
        }

    }
}
