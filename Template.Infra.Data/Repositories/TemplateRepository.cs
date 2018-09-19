using Template.Cadastro.Domain.DTO;
using Template.Cadastro.Domain.Entities;
using Template.Domain.Interfaces.Repositories;
using Template.Cadastro.Infra.Data.Context;
using System.Linq;
using Template.Framework;
using Template.Framework.Utils;

namespace Template.Cadastro.Infra.Data.Repositories
{
    public sealed class TemplateRepository : Base.Repository<TemplateEntidade>, ITemplateRepository
    {
        public TemplateContext _context { get => (TemplateContext)_db; }

        public TemplateRepository(TemplateContext db) : base(db)
        {
        }

        public IQueryable<TemplateEntidade> Listar(PesquisaTemplate pesquisa, Paginacao paginacao)
        {
            var templates = _context.Template
                                .Where(
                                        t=>t.Nome == (pesquisa.Nome ?? t.Nome) 
                                        || 
                                        t.IdUsuario == (pesquisa.IdUsuario ?? t.IdUsuario) 
                                        || 
                                        t.DataInclusao == (pesquisa.DataInclusao ?? t.DataInclusao)
                                      );

            if (!string.IsNullOrEmpty(paginacao.Search))
                templates = templates.Where(t => t.Nome.ToLower().Contains(paginacao.SearchLower) || t.Descricao.ToLower().Contains(paginacao.SearchLower));

            paginacao.count = templates.Count();

            templates = PaginacaoOrdenacao.AplicarPaginacao<TemplateEntidade>(templates, paginacao);

            return templates;
        }
    }
}
