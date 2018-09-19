using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Core.Domain.Entities.Base;

namespace Template.Cadastro.Domain.Entities.Validacoes
{
    public class TemplateValidation: Validation<TemplateEntidade>
    {
        public void ValidarNome()
        {
            RuleFor(t => t.Nome)
                .Length(2, 100)
                //.WithMessage("O campo nome deve ter entre 2 e 100 caracteres")
                .NotEmpty()
                .WithMessage("O campo Nome é obrigatório.");
        }

        public void ValidarDescricao()
        {
            RuleFor(t => t.Descricao)
                .MaximumLength(300)
                .WithMessage("o campo Descrição deve conter no máximo 300 caracteres");
        }

        public override void ConfigurarValidacoes()
        {
            ValidarNome();
            ValidarDescricao();
        }
    }
}
