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
        public IActionResult ObterSuperheroePorId(int id)
            => Resposta(_superheroeService.ObterSuperheroeCompletoPorId(id));

        [HttpGet("BuscarHeroisPorNome")]
        public IActionResult ObterSuperheroesPorstring(string nome)
            => Resposta(_superheroeService.ObterSuperheroesCompletoPorNome(nome));


        [HttpGet("ListaSuperHeroisPorPagina")]
        public IActionResult ObterListaSuperHeoresPaginada(string nome, int pagina, int qtheroispagina)
            => Resposta(_superheroeService.ObterListaSuperHeoresPaginada(nome, pagina, qtheroispagina));


        //Todo: Inserir os demais métodos que farão parte da API:
        // Cadastrar CPF que retorna token;
        // Verifica CPF pra liberar acesso;
        
    }
}
