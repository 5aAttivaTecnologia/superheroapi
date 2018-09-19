using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Core.Domain.Entities
{
    public interface IUsuario
    {
        string Nome { get; }
        bool Autenticado { get;}
    }
}
