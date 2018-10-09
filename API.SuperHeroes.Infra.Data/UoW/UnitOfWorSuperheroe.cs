using API.SuperHeroes.Domain.Interfaces.UoW;
using API.SuperHeroes.Infra.Data.Context;

namespace API.SuperHeroes.Infra.Data.UoW
{
    public class UnitOfWorkSuperheroes : IUnitOfWorkSuperheroes
    {
        SuperheroeContext _db;

        public UnitOfWorkSuperheroes(SuperheroeContext db)
        {
            _db = db;
        }

        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}
    