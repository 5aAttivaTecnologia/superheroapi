using API.SuperHeroes.Domain.Events;
using API.SuperHeroes.Domain.Interfaces;
using API.SuperHeroes.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.SuperHeroes.Api.Controllers
{
    //[AuthorizeJwt]
    [Produces("application/json")]
    [Route("api/Superheroes")]
    public class SuperheroeController : Base.BaseController
    {
        readonly ISuperheroeService _superheroeService;

        public SuperheroeController(
            ISuperheroeService superheroeService,
            IHandler<DomainNotification> domainNotificationHandler)
            : base(domainNotificationHandler)
        {

            _superheroeService = superheroeService;
        }

        [HttpGet("BuscarHeroisPorId")]
        public IActionResult ObterSuperheroePorId(int id, string token)
        {
            if (_superheroeService.ValidaTokenAttribute(token))
            {
                return Resposta(_superheroeService.ObterSuperheroeCompletoPorId(id));
            }
            else
            {
                return StatusCode(401, new
                {
                    sucesso = false,
                    erro = "Acesso Não Autorizado.Token Inválido ou Inexistente.Refaça a Autenticação e Repita o Operação.(Erro: 401)"
                });
            }
        }

        [HttpGet("BuscarHeroisPorNome")]
        public IActionResult ObterSuperheroesPorstring(string nome, string token)
        {
            if (_superheroeService.ValidaTokenAttribute(token))
            {
                return Resposta(_superheroeService.ObterSuperheroesCompletoPorNome(nome));
            }
            else
            {
                return StatusCode(401, new
                {
                    sucesso = false,
                    erro = "Acesso Não Autorizado.Token Inválido ou Inexistente.Refaça a Autenticação e Repita o Operação.(Erro: 401)"
                });
            }
        }


        [HttpGet("ListaSuperHeroisPorPagina")]
        public IActionResult ObterListaSuperHeoresPaginada(string nome, int pagina, int qtheroispagina, string token)
        {
            if (_superheroeService.ValidaTokenAttribute(token))
            {
                return Resposta(_superheroeService.ObterListaSuperHeroesPaginada(nome, pagina, qtheroispagina));
            }
            else
            {
                return StatusCode(401, new
                {
                    sucesso = false,
                    erro = "Acesso Não Autorizado.Token Inválido ou Inexistente.Refaça a Autenticação e Repita o Operação.(Erro: 401)"
                });
            }          

        }
    }
}
