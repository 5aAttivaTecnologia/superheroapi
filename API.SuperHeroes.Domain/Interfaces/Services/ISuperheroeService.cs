using API.SuperHeroes.Domain.Entidade;
using System.Collections.Generic;

namespace API.SuperHeroes.Domain.Interfaces.Services
{
    public interface ISuperheroeService
    {
        Superheroe ObterSuperheroeCompletoPorId(int superheroId, string token);
        List<Superheroe> ObterSuperheroesCompletoPorNome(string nome, string token);
        List<Superheroe> ObterListaSuperHeoresPaginada(string nome, int pagina, int nrpagina, string token);
        bool ValidaTokenAttribute(string token);
    }
}
