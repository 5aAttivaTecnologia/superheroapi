using System;
using System.Collections.Generic;
using System.Text;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Entities;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Interfaces.Repositories;
using System.Linq;
using Template.Cadastro.Infra.Data.Repositories.Base;

namespace Template.Cadastro.Infra.CrossCutting.Autenticacao.Data.Repositories
{

    public sealed class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public AutenticacaoContext _context { get { return (AutenticacaoContext)_db; } }

        public UsuarioRepository(AutenticacaoContext db)
            : base(db)
        {
        }

        public Usuario ObterUsuario(string login, string senha)
        {
            return _context.Usuario.SingleOrDefault(u => u.Login == login && u.Senha == senha);
        }
    }
}
