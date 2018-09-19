using System.Linq;
using System.Linq.Dynamic.Core;

namespace Template.Framework.Utils
{
    public class PaginacaoOrdenacao
    {
        public IQueryable AplicarPaginacaoDataTable(IQueryable query, Paginacao paginacao)
        {
            if (typeof(PaginacaoNull) == paginacao.GetType())
                return query;

            if (!string.IsNullOrEmpty(paginacao.Sort))
                query = query.OrderBy(paginacao.Sort);

            query = query.Skip(paginacao.start).Take(paginacao.length);

            return query;
        }

        public static IQueryable<T> AplicarPaginacao<T>(IQueryable query, Paginacao paginacao)
        {
            return (IQueryable<T>)new PaginacaoOrdenacao().AplicarPaginacaoDataTable(query, paginacao);
        }
    }
}
