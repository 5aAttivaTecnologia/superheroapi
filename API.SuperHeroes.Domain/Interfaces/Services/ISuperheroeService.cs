using API.SuperHeroes.Domain.Entidade;
using System.Collections.Generic;

namespace API.SuperHeroes.Domain.Interfaces.Services
{
    public interface ISuperheroeService
    {
        Superheroe ObterSuperheroeCompletoPorId(int superheroId);
        List<Superheroe> ObterSuperheroesCompletoPorNome(string nome);
        List<Superheroe> ObterListaSuperHeroesPaginada(string nome, int pagina, int nrpagina);
        bool ValidaTokenAttribute(string token);
    }
}
