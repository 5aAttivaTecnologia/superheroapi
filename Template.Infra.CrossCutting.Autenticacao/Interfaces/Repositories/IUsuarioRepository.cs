using System;
using System.Collections.Generic;
using System.Text;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Entities;
using Template.Core.Domain.Interfaces.Repositories.Base;

namespace Template.Cadastro.Infra.CrossCutting.Autenticacao.Interfaces.Repositories
{
    public interface IUsuarioRepository: IRepository<Usuario>
    {
        Usuario ObterUsuario(string login, string senha);
    }
}
