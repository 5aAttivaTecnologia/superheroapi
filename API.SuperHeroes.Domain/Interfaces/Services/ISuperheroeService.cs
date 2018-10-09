using API.SuperHeroes.Domain.DTO;
using System.Collections.Generic;

namespace API.SuperHeroes.Domain.Interfaces.Services
{
    public interface ISuperheroeService
    {
        SuperheroeDTO ObterSuperheroeCompletoPorId(int superheroId);
        List<SuperheroeDTO> ObterSuperheroesCompletoPorNome(string nome);
        List<SuperheroeDTO> ObterListaSuperHeoresPaginada(string nome, int pagina, int nrpagina);
    }
}
