using API.SuperHeroes.Domain.Entidade.Validacoes;
using System;

namespace API.SuperHeroes.Domain.Entidade
{
    public class Usuario
         : Base.Entidade<Usuario>
    {

        public Usuario()
             : base(new UsuarioValidador())
        {

        }

        public string Nr_CPF { get; set; }
        public string Id_Hash_autorização { get; set; }
        public DateTime Dt_Atualizacao_HasH_Autenticacao { get; set; }
       

        public override bool Validar()
        {
            return this.Validar(this);
        }
    }
}
