using System;
using System.Linq;
using API.SuperHeroes.Domain.Entidade;
using API.SuperHeroes.Domain.Interfaces.Repositories;
using API.SuperHeroes.Domain.Interfaces.UoW;
using API.SuperHeroes.Infra.Data.Context;
using API.SuperHeroes.Infra.Data.Enum;

namespace API.SuperHeroes.Infra.Data.Repositories
{
    public sealed class SuperheroeRepository
        : Base.Repository<Superheroe>, ISuperheroeRepository
    {
        public SuperheroeContext _superheroeContext { get => (SuperheroeContext)_context; }

        public SuperheroeRepository(SuperheroeContext superheroeContext, IUnitOfWorkSuperheroes unitOfWorkSuperheroes)
            : base(superheroeContext, unitOfWorkSuperheroes)
        {
        }

        public IQueryable<Superheroe> ObterSuperheroeCompltoPorId(int superheroeId)
        {
            return from x in _superheroeContext.Superheroes
                   where x.Id_superheroe == superheroeId
                      && x.St_ativo == Convert.ToInt32(EStatus.Ativo).ToString()
                   select new Superheroe
                   {
                       Id_superheroe = x.Id_superheroe,
                       Nm_superheroe = x.Nm_superheroe,
                       Ds_superheroe = x.Ds_superheroe,
                       St_ativo      = x.St_ativo
                   };
        }

        IQueryable<Superheroe> ISuperheroeRepository.ObterSuperheroesCompltoPorNome(string superheroename)
        {
            return from x in _superheroeContext.Superheroes
                   where x.Nm_superheroe.ToLower().Contains(superheroename.ToLower())
                   && x.St_ativo == Convert.ToInt32(EStatus.Ativo).ToString()
                   select new Superheroe
                   {
                       Id_superheroe = x.Id_superheroe,
                       Nm_superheroe = x.Nm_superheroe,
                       Ds_superheroe = x.Ds_superheroe,
                       St_ativo      = x.St_ativo
                   };
        }

        IQueryable<Superheroe> ISuperheroeRepository.ObterListaSuperHeoresPaginada(string nome, int pagina, int nrpagina)
        {
            var query = (from x in _superheroeContext.Superheroes
                         where x.St_ativo == Convert.ToInt32(EStatus.Ativo).ToString()
                         select new Superheroe
                         {
                             Id_superheroe = x.Id_superheroe,
                             Nm_superheroe = x.Nm_superheroe,
                             Ds_superheroe = x.Ds_superheroe,
                             St_ativo      = x.St_ativo
                         });

            if (!string.IsNullOrEmpty(nome))
                query = query.Where(q => q.Nm_superheroe.ToLower().Contains(nome.ToLower()));  

            return query.Skip((pagina - 1) * nrpagina).Take(nrpagina);

        }

        
    }
}
