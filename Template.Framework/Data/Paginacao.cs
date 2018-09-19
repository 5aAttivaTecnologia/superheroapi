using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net.Http;

namespace Template.Framework
{
    public class Paginacao
    {
        public Paginacao()
        {
            //MapeiaRequisicaoDataTable();
        }

        public int draw { get; set; }
        /// <summary>
        /// pagina atual
        /// </summary>
        public int start { get; set; }
        /// <summary>
        /// total de registros por página
        /// </summary>
        public int length { get; set; }
        /// <summary>
        /// total de registros
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// Campo de ordenação
        /// </summary>
        public string Sort { get; set; }

        public string Search { get; set; }

        public string SearchLower { get { return string.IsNullOrEmpty(Search) ? null : Search.ToLower(); } }

        public object ObjetoLimpo
        {
            get => new { draw = draw, start = start, length = length, count = count, Sort = Sort, Search = Search };
        }

        public static PaginacaoNull PaginacaoNULL
        {
            get
            {
                return new PaginacaoNull();
            }
        }

        public virtual void MapeiaRequisicaoDataTable(HttpRequest request)
        {
            var campos = request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());

            if (!campos.Keys.Contains("order[0][column]"))
                return;

            var sortColumn = campos["columns[" + campos["order[0][column]"].FirstOrDefault() + "][data]"];
            var sortColumnDir = campos["order[0][dir]"];

            Search = campos["search[value]"];

            Sort = !string.IsNullOrEmpty(sortColumn) ? string.Format("{0} {1}", sortColumn, sortColumnDir) : null;
        }
    }
}
