using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Template.Cadastro.Domain.DTO;
using Template.Cadastro.Domain.Entities;
using Template.Core.Domain.Interfaces.Repositories.Base;
using Template.Framework;

namespace Template.Domain.Interfaces.Repositories
{
    public interface ITemplateRepository: IRepository<TemplateEntidade>
    {
        IQueryable<TemplateEntidade> Listar(PesquisaTemplate pesquisa, Paginacao paginacao);
    }
}
