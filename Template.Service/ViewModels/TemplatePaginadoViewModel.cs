using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Framework;

namespace Template.Cadastro.Api.ViewModels
{
    public sealed class TemplatePaginadoViewModel
    {
        public IEnumerable<TemplateViewModel> Templates { get; set; }
        public Paginacao Paginacao { get; set; }
    }
}
