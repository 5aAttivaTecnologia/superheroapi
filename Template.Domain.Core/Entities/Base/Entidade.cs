using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Template.Core.Domain.Events;

namespace Template.Core.Domain.Entities.Base
{
    public abstract class Entidade<T>
    {
        public int Id { get; set; }

        Validation<T> _validador;

        ValidationResult resultadoValidacao;

        public Entidade(Validation<T> validador)
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
