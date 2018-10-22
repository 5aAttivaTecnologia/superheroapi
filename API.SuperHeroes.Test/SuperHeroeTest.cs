using System;
using API.SuperHeroes.Domain.Interfaces.Repositories;
using Bogus;
using Xunit;
using API.SuperHeroes.Domain.Entidade;
using Moq;
using System.Collections.Generic;
using System.Linq;
using API.SuperHeroes.Domain.Service;
using API.SuperHeroes.Domain.Handlers;
using API.SuperHeroes.Domain.Interfaces.UoW;
using Bogus.DataSets;

namespace API.SuperHeroes.Test
{

    public class SuperHeroeTest
    {
        public SuperheroeService _superheroeService;
        public SuperheroeService _superheroeService2;

        public Mock<ISuperheroeRepository> _superheroerepository;
        public Mock<ISuperheroeRepository> _superheroerepository2;
        public Mock<IUsuarioRepository> _usuarioRepository;
        public Mock<IUnitOfWorkSuperheroes> _uow;
        public List<Superheroe> lsuperheroe;

        public Superheroe _superheroe;

        public Random _random;

        public int superHeroId;
        public int SuperheroeNotId;
        public string SuperHeroeName;
        public string SuperHeroeNameTrue;
        public string SuperHeroeNameFalse;
        public int paginas = 1;
        public int paginas2 = 2;
        public int itens2 = 2;
        public int itens = 1;

        public SuperHeroeTest()
        {
            _superheroerepository = new Mock<ISuperheroeRepository>();
            _superheroerepository2 = new Mock<ISuperheroeRepository>();
            _usuarioRepository = new Mock<IUsuarioRepository>();
            _uow = new Mock<IUnitOfWorkSuperheroes>();
            _superheroeService = new SuperheroeService(_superheroerepository.Object, _usuarioRepository.Object, new DomainNotificationHandler(), _uow.Object);
            _superheroeService2 = new SuperheroeService(_superheroerepository2.Object, _usuarioRepository.Object, new DomainNotificationHandler(), _uow.Object);

            _random = new Random();
            superHeroId = _random.Next(1, 256);
            SuperheroeNotId = 321;
            SuperHeroeName = "Steve Vai Pra Onde";
            SuperHeroeNameFalse = "Foi";
            SuperHeroeNameTrue = "vai";
            ObterObjetos();
            SetupRepository();

        }

        [Fact]
        public void ObterSuperHeroeByIdTest()
        {
           Superheroe teste = _superheroeService.ObterSuperheroeCompletoPorId(superHeroId);

            Assert.NotNull(teste);
        }

        [Fact]
        public void ObterSuperHeroeByIdTestNull()
        {
            Superheroe teste = _superheroeService.ObterSuperheroeCompletoPorId(SuperheroeNotId);

            Assert.Null(teste);
        }

        [Fact]
        public void ObterSuperHeroeByNameTest()
        {
            List<Superheroe> teste = _superheroeService.ObterSuperheroesCompletoPorNome(SuperHeroeNameTrue);

            Assert.True(teste.Count == 1);
        }


        [Fact]
        public void ObterSuperHeroeByNameTestFalse()
        {
            List<Superheroe> teste = _superheroeService.ObterSuperheroesCompletoPorNome(SuperHeroeNameFalse);

            Assert.False(teste.Count == 1);
        }

        [Fact]
        public void ObterListofSuperHeroesByNameorPageTestTrue()
        {
            List<Superheroe> teste = _superheroeService.ObterListaSuperHeroesPaginada(SuperHeroeNameTrue, 1, 1);

            Assert.True(teste.Count == 1);
        }

        [Fact]
        public void ObterListofSuperHeroesByNameorPageTestTrue2()
        {
            List<Superheroe> teste = _superheroeService2.ObterListaSuperHeroesPaginada(SuperHeroeNameTrue, 2, 1);

            Assert.True(teste.Count == 1);
        }

        [Fact]
        public void ObterListofSuperHeroesByNameorPageTestFalse()
        {
            List<Superheroe> teste = _superheroeService.ObterListaSuperHeroesPaginada(SuperHeroeNameTrue, 1, 2);

            Assert.False(teste.Count == 1);
        }

        [Fact]
        public void ObterListofSuperHeroesByNameorPageTestFalse2()
        {
            List<Superheroe> teste = _superheroeService2.ObterListaSuperHeroesPaginada(SuperHeroeNameTrue, 2, 2);

            Assert.False(teste.Count == 1);
        }

        public void SetupRepository()
        {
            _superheroerepository.Setup(x => x.ObterSuperheroeCompltoPorId(superHeroId)).Returns(lsuperheroe.AsQueryable());
            _superheroerepository.Setup(x => x.ObterSuperheroesCompltoPorNome(SuperHeroeNameTrue)).Returns(lsuperheroe.AsQueryable());
            _superheroerepository.Setup(x => x.ObterListaSuperHeoresPaginada(SuperHeroeNameTrue, paginas, itens)).Returns(lsuperheroe.AsQueryable());
            _superheroerepository2.Setup(x => x.ObterListaSuperHeoresPaginada(SuperHeroeNameTrue, paginas2, itens)).Returns(lsuperheroe.AsQueryable());
        }

        private void ObterObjetos()
        {            
            _superheroe = new Faker<Superheroe>()
                .RuleFor(b => b.Id_superheroe, f => superHeroId)
                .RuleFor(b => b.Nm_superheroe, f => SuperHeroeName)
                .RuleFor(b => b.Ds_superheroe, f => f.Lorem.Sentences(3))
                ;

            lsuperheroe = new List<Superheroe>();
            lsuperheroe.Add(_superheroe);
        }
    }
}

