using API.SuperHeroes.Domain.Interfaces.UoW;
using API.SuperHeroes.Infra.Data.Context;

namespace API.SuperHeroes.Infra.Data.UoW
{
    public class UnitOfWorkUsuario : IUnitOfWorkUsuario
    {
        UsuarioContext _db;

        public UnitOfWorkUsuario(UsuarioContext db)
        {
            _db = db;
        }

        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}
