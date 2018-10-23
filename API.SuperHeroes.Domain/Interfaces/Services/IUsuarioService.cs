using API.SuperHeroes.Domain.Entidade;
using System.Collections.Generic;

namespace API.SuperHeroes.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Usuario ObterUsuarioPorCPF(string nrcpf);
        Usuario CadastraUsuario(string nrcpf);
        List<Usuario> ListaUsuarios();
        bool ValidaSenha(string senhaadmin);
    }
}
