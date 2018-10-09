using API.SuperHeroes.Domain.DTO;
using API.SuperHeroes.Domain.Entidade;
using API.SuperHeroes.Domain.Interfaces.Base;
using System.Collections.Generic;
using System.Linq;


namespace API.SuperHeroes.Domain.Interfaces.Repositories
{
    public interface ISuperheroeRepository 
        : IRepository<Superheroe>
    {
        IQueryable<SuperheroeDTO> ObterSuperheroeCompltoPorId(int superheroeId);
        IQueryable<SuperheroeDTO> ObterSuperheroesCompltoPorNome(string superheroename);
        IQueryable<SuperheroeDTO> ObterListaSuperHeoresPaginada(string nome, int pagina, int nrpagina);
    }
}
