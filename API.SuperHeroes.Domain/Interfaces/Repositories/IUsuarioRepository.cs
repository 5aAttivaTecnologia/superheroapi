using API.SuperHeroes.Domain.DTO;
using API.SuperHeroes.Domain.Entidade;
using API.SuperHeroes.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.SuperHeroes.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
        : IRepository<Usuario>
    {       
        IQueryable<UsuarioDTO> ObterUsuarioPorCPF(string nrcpf);        
    }
}
