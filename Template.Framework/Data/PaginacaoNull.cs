using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Framework
{
    public class PaginacaoNull: Paginacao
    {
        public override void MapeiaRequisicaoDataTable(HttpRequest request)
        {           
        }
    }
}
