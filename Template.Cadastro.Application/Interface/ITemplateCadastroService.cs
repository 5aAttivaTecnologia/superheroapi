using System;
using System.Collections.Generic;
using System.Text;
using Template.Cadastro.Application.ViewModels;
using Template.Cadastro.Domain.Entities;

namespace Template.Cadastro.Application.Interface
{
    public interface ITemplateCadastroService
    {
        TemplateEntidadeViewModel Cadastrar(TemplateEntidadeViewModel template);
    }
}
