using System;
using System.Collections.Generic;
using System.Text;
using Template.Core.Domain.Entities.Base;

namespace Template.Core.Domain.Entities
{
    public class Teste : Base.Entidade<Teste>
    {
        public Teste(Validation<Teste> validador) : base(validador)
        {
        }

        public override bool Validar()
        {
            return base.Validar(this);
        }
    }
}
