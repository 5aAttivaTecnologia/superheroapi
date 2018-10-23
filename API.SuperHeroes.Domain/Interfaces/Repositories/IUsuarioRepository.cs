using API.SuperHeroes.Domain.Entidade;
using API.SuperHeroes.Domain.Interfaces.Base;
using System.Linq;

namespace API.SuperHeroes.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
        : IRepository<Usuario>
    {       
        IQueryable<Usuario> ObterUsuarioPorCPF(string nrcpf);
        IQueryable<Usuario> BuscaToken(string token);
        void CadastraUsuario(Usuario nrcpf);
        void AtualizaHash(Usuario usuario);
        IQueryable<Usuario> ListaUsuarios();
    }
}
