using API.SuperHeroes.Domain.Entidade;

namespace API.SuperHeroes.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Usuario ObterUsuarioPorCPF(string nrcpf);
        Usuario CadastraUsuario(string nrcpf);
    }
}
