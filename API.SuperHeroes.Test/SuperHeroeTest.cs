using System;
using API.SuperHeroes.Domain.Interfaces.Repositories;
using API.SuperHeroes.Domain.Interfaces.Services;
using static Bogus.DataSets.Name;
using Bogus;
using Xunit;
using API.SuperHeroes.Domain.Entidade;

namespace API.SuperHeroes.Test
{

    public class SuperHeroeTest
    {
        public Faker<ISuperheroeService> _supoerheroservice;

        public Faker<ISuperheroeRepository> _superheroerepository;

        public Superheroe _superheroe;

        public Random _random;

        public SuperHeroeTest()
        {
            _superheroerepository = new Faker<ISuperheroeRepository>();

            _supoerheroservice = new Faker<ISuperheroeService>();

            _random = new Random();

            ObterObjetos();

        }

        [Fact]
        public void ObterSuperHeroeById()
        {
            //_supoerheroservice.
        }

        [Fact]
        public void ObterSuperHeroeByName()
        {
            throw new NotSupportedException();
        }

        [Fact]
        public void ObterListofSuperHeroesByNameorPage()
        {
            throw new NotSupportedException();
        }


        private void ObterObjetos()
        {
            _superheroe = new Faker<Superheroe>()
                .RuleFor(b => b.Id_superheroe, f => _random.Next(1, 256))
                .RuleFor(b => b.Nm_superheroe, f => f.Name.FullName(Gender.Male))
                .RuleFor(b => b.Ds_superheroe, f => f.Lorem.Sentences(3))
                ;

        }
    }
}

