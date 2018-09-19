using System.Collections;

namespace Template.Framework
{
    public class DataTablesResponse
    {
        public int draw { get; private set; }
        public IEnumerable data { get; private set; }
        public int recordsTotal { get; private set; }
        public int recordsFiltered { get; private set; }

        public DataTablesResponse(int draw, IEnumerable data, int recordsFiltered, int recordsTotal)
        {
            this.draw = draw;
            this.data = data;
            this.recordsFiltered = recordsFiltered;
            this.recordsTotal = recordsTotal;
        }

        public static DataTablesResponse Reposta(Paginacao paginacao, IEnumerable data)
        {
            return new DataTablesResponse(paginacao.draw, data, paginacao.count, paginacao.count);
        }
    }
}
