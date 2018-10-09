namespace API.SuperHeroes.Domain.DTO
{
    public class UsuarioDTO
    {
        public int NR_CPF { get; set; }
        public string Id_hash_autenticacao { get; set; }
        public string Dt_atualizacao_hash { get; set; }
    }
}
