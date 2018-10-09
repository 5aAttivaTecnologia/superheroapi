using FluentValidation;

namespace API.SuperHeroes.Domain.Entidade.Validacoes.Base
{
    public abstract class Validador<T> : AbstractValidator<T>
    {
        public abstract void ConfigurarValidacoes();
    }
}
