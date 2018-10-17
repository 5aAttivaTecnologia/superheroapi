using API.SuperHeroes.Domain.Entidade;
using API.SuperHeroes.Domain.Interfaces.Base;
using System.Linq;


namespace API.SuperHeroes.Domain.Interfaces.Repositories
{
    public interface ISuperheroeRepository 
        : IRepository<Superheroe>
    {
        IQueryable<Superheroe> ObterSuperheroeCompltoPorId(int superheroeId);
        IQueryable<Superheroe> ObterSuperheroesCompltoPorNome(string superheroename);
        IQueryable<Superheroe> ObterListaSuperHeoresPaginada(string nome, int pagina, int nrpagina);
         
    }
}
