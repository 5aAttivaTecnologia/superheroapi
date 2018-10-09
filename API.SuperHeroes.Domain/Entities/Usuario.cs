using API.SuperHeroes.Domain.Entidade.Validacoes;

namespace API.SuperHeroes.Domain.Entidade
{
    public class Usuario
         : Base.Entidade<Usuario>
    {

        public Usuario()
             : base(new UsuarioValidador())
        {

        }

        public int Nr_CPF { get; set; }
        public string Id_Hash_autorização { get; set; }
        public string Dt_Atualizacao_HasH_Autenticacao { get; set; }

        public override bool Validar()
        {
            return this.Validar(this);
        }
    }
}
