using System;
using System.Collections.Generic;
using System.Text;
using Template.Cadastro.Domain.Entities;

namespace Template.Domain.Interfaces.Services
{
    public interface ITemplateService
    {
        TemplateEntidade Cadastrar(TemplateEntidade template);
        TemplateEntidade Alterar(TemplateEntidade template);
        void Remover(int id);
    }
}
