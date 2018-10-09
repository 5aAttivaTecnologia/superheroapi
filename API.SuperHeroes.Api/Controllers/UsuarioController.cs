using Amil.Framework.NetCore.Autenticacao.Token.Attributes;
using API.SuperHeroes.Domain.Events;
using API.SuperHeroes.Domain.Interfaces;
using API.SuperHeroes.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.SuperHeroes.Api.Controllers
{
    //[AuthorizeJwt]
    [Produces("application/json")]
    [Route("api/Superheroes")]
    public class UsuarioController : Base.BaseController
    {
        readonly IUsuarioService  _ususarioService;

        public UsuarioController(
            IUsuarioService usuarioService,
            IHandler<DomainNotification> domainNotificationHandler)
            : base(domainNotificationHandler)
        {
            _ususarioService = usuarioService;
        }

        [HttpGet("buscarusuario")]
        public IActionResult ObterSuperheroePorId(string cpf)
            => Resposta( _ususarioService.ObterUsuarioPorCPF(cpf));
    }
}
