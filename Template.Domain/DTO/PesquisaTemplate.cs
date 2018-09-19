using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Cadastro.Domain.DTO
{
    public sealed class PesquisaTemplate
    {
        public string Nome { get; set; }
        public DateTime? DataInclusao { get; set; }
        public int? IdUsuario { get; set; }
    }
}
