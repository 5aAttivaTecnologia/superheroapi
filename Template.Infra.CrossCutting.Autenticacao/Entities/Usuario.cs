using System;
using System.Collections.Generic;
using System.Text;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Entities.Validacoes;
using Template.Core.Domain.Entities.Base;

namespace Template.Cadastro.Infra.CrossCutting.Autenticacao.Entities
{
    public sealed class Usuario : Entidade<Usuario>
    {
        public Usuario() : base(new UsuarioValidation())
        {
        }

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public override bool Validar()
        {
            return Validar(this);
        }
    }
}
