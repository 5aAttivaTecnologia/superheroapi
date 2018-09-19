using System;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Template.Cadastro.Api.Controllers.Base;
using Template.Cadastro.Api.ViewModels;
using Template.Cadastro.Infra.CrossCutting.Autenticacao;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Entities;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Interfaces.Services;
using Template.Core.Domain.Events;
using Template.Core.Domain.Interfaces;
using System.Security.Claims;
using System.Security.Principal;

namespace Template.Cadastro.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Autenticacao")]
    public class AutenticacaoController : BaseController
    {
        readonly TokenDescriptor _tokenDescriptor;
        readonly IUsuarioService _usuarioService;
        readonly IMapper _mapper;

        public AutenticacaoController(
                                         IHandler<DomainNotification> domainNotificationHandler,
                                         TokenDescriptor tokenDescriptor,
                                         IUsuarioService usuarioService,
                                         IMapper mapper
                                     )
            : base(domainNotificationHandler)
        {
            _usuarioService = usuarioService;
            _tokenDescriptor = tokenDescriptor;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]LoginViewModel loginViewModel)
        {
            if (!ValidarModelState())
                return Resposta();

            var usuario = _mapper.Map<Usuario>(loginViewModel);

            loginViewModel = _mapper.Map<LoginViewModel>(_usuarioService.Autenticar(usuario));

            return Resposta(GerarTokenUsuario(loginViewModel));
        }

        private object GerarTokenUsuario(LoginViewModel login)
        {
            if (login == null)
                return login;

            var handler = new JwtSecurityTokenHandler();
            var signingConf = new SigningCredentialsConfiguration();

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(login.Login, "Login"),
                new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, login.Login)
                }
            );

            var token = new SecurityTokenDescriptor
            {
                Issuer = _tokenDescriptor.Issuer,
                Audience = _tokenDescriptor.Audience,
                SigningCredentials = signingConf.SigningCredentials,
                Subject = identity,
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(_tokenDescriptor.MinutesValid)
            };

            var securityToken = handler.CreateToken(token);

            var encodedJwt = handler.WriteToken(securityToken);

            var response = new
            {
                access_token = encodedJwt,
                expires_in = DateTime.Now.AddMinutes(_tokenDescriptor.MinutesValid),
                user = new
                {
                    login = login.Login,
                    nome = login.Nome
                }
            };

            return response;
        }
    }
}