using System;
using System.Collections.Generic;
using System.Text;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Entities;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Interfaces.Repositories;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Interfaces.Services;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Interfaces.UoW;
using Template.Core.Domain.Events;
using Template.Core.Domain.Interfaces;
using Template.Core.Domain.Services.Base;
using Template.Core.Infra.Data.Interfaces.UoW;

namespace Template.Cadastro.Infra.CrossCutting.Autenticacao.Services
{
    public sealed class UsuarioService : Service<Usuario>, IUsuarioService
    {
        IUsuarioRepository _usuarioRepository;

        public UsuarioService(
                              IUsuarioRepository usuarioRepository,
                              IHandler<DomainNotification> domainNotification,
                              IUnitOfWorkAutenticacao unitOfWork
                             )
            : base(domainNotification, unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Autenticar(Usuario usuario)
        {
            if(!VerificarEntidade(usuario))
                return usuario;

            usuario = _usuarioRepository.ObterUsuario(usuario.Login, usuario.Senha);

            if (usuario == null)
                Notificar(new DomainNotification("Erro", "Os dados de acesso estão incorretos"));

            return usuario;
        }
    }
}
