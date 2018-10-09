using API.SuperHeroes.Domain.DTO;
using API.SuperHeroes.Domain.Entidade;
using API.SuperHeroes.Domain.Interfaces.Repositories;
using API.SuperHeroes.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.SuperHeroes.Infra.Data.Repositories
{
    public sealed class UsuarioRepository
        : Base.Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioContext _usuarioContext { get => (UsuarioContext)_context; }

        public UsuarioRepository(UsuarioContext usuarioContext)
            : base(usuarioContext)
        {
        }

        public IQueryable<UsuarioDTO> ObterUsuarioPorCPF(string nrcpf)
        {
            return from x in _usuarioContext.Usuario
                   where x.Nr_CPF.Equals(nrcpf)
                   select new UsuarioDTO
                   {
                       NR_CPF = x.Nr_CPF,
                       Id_hash_autenticacao = x.Id_Hash_autorização,
                       Dt_atualizacao_hash = x.Dt_Atualizacao_HasH_Autenticacao
                   };
        }
    }
}
