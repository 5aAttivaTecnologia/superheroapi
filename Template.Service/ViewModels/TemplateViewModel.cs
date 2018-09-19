using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Template.Cadastro.Api.ViewModels
{
    public class TemplateViewModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int? IdUsuario { get; set; }
        public bool Ativo { get; set; }
    }
}
