using System;
using System.Collections.Generic;
using System.Text;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Entities;

namespace Template.Cadastro.Infra.CrossCutting.Autenticacao.Interfaces.Services
{
    public interface IUsuarioService
    {
        Usuario Autenticar(Usuario usuario);
    }
}
