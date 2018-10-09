using API.SuperHeroes.Domain.DTO;
using API.SuperHeroes.Domain.Entidade;
using API.SuperHeroes.Domain.Events;
using API.SuperHeroes.Domain.Interfaces;
using API.SuperHeroes.Domain.Interfaces.Repositories;
using API.SuperHeroes.Domain.Interfaces.Services;
using API.SuperHeroes.Domain.Interfaces.UoW;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace API.SuperHeroes.Domain.Service
{
    public sealed class SuperheroeService : Base.Service<Superheroe>, ISuperheroeService
    {
        readonly ISuperheroeRepository _superheroeRepository;

        public SuperheroeService(
            ISuperheroeRepository superheroeRepository,
            IHandler<DomainNotification> domainNotification,
            IUnitOfWorkSuperheroes unitOfWorkSuperheroes,
            IUnitOfWorkUsuario unitOfWorkUsuario)
            : base(domainNotification, unitOfWorkSuperheroes, unitOfWorkUsuario)
        {
            _superheroeRepository = superheroeRepository;
        }



        public SuperheroeDTO ObterSuperheroeCompletoPorId(int superheroId)
        {
            var personagem = _superheroeRepository.ObterSuperheroeCompltoPorId(superheroId).FirstOrDefault();

            if (personagem == null)
                return personagem;

            var pathImagem = $"{Directory.GetCurrentDirectory()}\\..\\imagens\\";

            personagem.Im_superheroe = File.Exists($"{pathImagem}{personagem.Id_superheroe}.jpg")
                ? File.ReadAllBytes($"{pathImagem}{personagem.Id_superheroe}.jpg")
                : File.ReadAllBytes($"{pathImagem}default.jpg");

            return personagem;
        }

        public List<SuperheroeDTO> ObterSuperheroesCompletoPorNome(string nome)
        {
            var listapersonagens = _superheroeRepository.ObterSuperheroesCompltoPorNome(nome).ToList();

            if (listapersonagens == null)
                return listapersonagens;

            foreach (SuperheroeDTO personagem in listapersonagens)
            {
                var pathImagem = $"{Directory.GetCurrentDirectory()}\\..\\imagens\\";

                personagem.Im_superheroe = File.Exists($"{pathImagem}{personagem.Id_superheroe}.jpg")
                    ? File.ReadAllBytes($"{pathImagem}{personagem.Id_superheroe}.jpg")
                    : File.ReadAllBytes($"{pathImagem}default.jpg");
            }


            return listapersonagens;
        }

        public List<SuperheroeDTO> ObterListaSuperHeoresPaginada(string nome, int pagina, int nrpagina)
        {
            if (nrpagina == 0)
                nrpagina = 9;

            List<SuperheroeDTO> listapersonagens = _superheroeRepository.ObterListaSuperHeoresPaginada(nome, pagina, nrpagina).ToList();

                if (listapersonagens == null)
                    return listapersonagens;

                foreach (SuperheroeDTO personagem in listapersonagens)
                {
                    var pathImagem = $"{Directory.GetCurrentDirectory()}\\..\\imagens\\";

                    personagem.Im_superheroe = File.Exists($"{pathImagem}{personagem.Id_superheroe}.jpg")
                        ? File.ReadAllBytes($"{pathImagem}{personagem.Id_superheroe}.jpg")
                        : File.ReadAllBytes($"{pathImagem}default.jpg");
                }   

            return listapersonagens;
        }

    }
}
