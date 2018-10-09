using Microsoft.AspNetCore.Http;
using System;
using Template.Core.Domain.Entities;

namespace Template.Cadastro.Infra.CrossCutting.Autenticacao.Entities
{
    public sealed class AspNetUser : IUsuario
    {
        IHttpContextAccessor _accessor;

        public AspNetUser()
        {
        }

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Nome => _accessor.HttpContext.User.Identity.Name;

        public bool Autenticado => _accessor.HttpContext.User.Identity.IsAuthenticated;
    }
}
