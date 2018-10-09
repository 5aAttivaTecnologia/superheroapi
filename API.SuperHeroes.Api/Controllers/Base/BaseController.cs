using System.Linq;
using API.SuperHeroes.Domain.Events;
using API.SuperHeroes.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.SuperHeroes.Api.Controllers.Base
{
    [Produces("application/json")]
    //[Route("api/Base")]
    public class BaseController : Controller
    {
        IHandler<DomainNotification> _domainNotificationHandler;

        public BaseController(IHandler<DomainNotification> domainNotificationHandler)
        {
            _domainNotificationHandler = domainNotificationHandler;
        }

        protected IActionResult Resposta(object resultado = null)
        {
            if (ValidarOperacao())
                return Ok(new { sucesso = true, dados = resultado });

            return BadRequest(new { sucesso = false, erros = _domainNotificationHandler.ObterValores().Select(x=>x.Valor)});
        }

        protected bool ValidarOperacao()
        {
            return !_domainNotificationHandler.ExistemNotificacoes();
        }

        protected bool ValidarModelState()
        {
            if (ModelState.IsValid)
                return true;

            NotificarErrosModelState();

            return false;
        }

        protected void NotificarErrosModelState()
        {
            var erros = ModelState.Values.SelectMany(x => x.Errors);

            foreach (var erro in erros)
                DomainEvent.Raise(new DomainNotification(string.Empty, erro.ErrorMessage));
        }
    }
}