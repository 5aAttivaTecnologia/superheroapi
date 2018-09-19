using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Core.Domain.Entities.Base
{
    public abstract class Validation<T> : AbstractValidator<T>
    {
        public abstract void ConfigurarValidacoes();
    }
}
