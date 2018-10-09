using API.SuperHeroes.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.SuperHeroes.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        UsuarioDTO ObterUsuarioPorCPF(string nrcpf);
    }
}
