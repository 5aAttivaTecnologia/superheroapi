using System;
using System.Collections.Generic;
using System.Text;
using Template.Core.Domain.Entities.Base;
using Template.Cadastro.Domain.Entities.Validacoes;

namespace Template.Cadastro.Domain.Entities
{
    public sealed class TemplateEntidade : Entidade<TemplateEntidade>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }
        public int IdUsuario { get; set; }

        public TemplateEntidade():base(new TemplateValidation())
        {
  
        }

        public override bool Validar()
        {
            return Validar(this);
        }
    }
}
