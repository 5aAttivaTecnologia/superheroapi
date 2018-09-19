using Microsoft.EntityFrameworkCore;
using System.Linq;
using Template.Core.Domain.Entities.Base;
using Template.Core.Domain.Interfaces.Repositories.Base;

namespace Template.Cadastro.Infra.Data.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T: Entidade<T>
    {
        protected DbContext _db;
        DbSet<T> _dbEntidade;

        public Repository(DbContext db)
        {
            _db = db;

            _dbEntidade = _db.Set<T>();
        }

        public void Adicionar(T entidade)
        {
            _dbEntidade.Add(entidade);
        }

        public void Atualizar(T entidade)
        {
            _dbEntidade.Update(entidade);
        }

        public T Buscar(int id)
        {
            return _dbEntidade.Find(id);
        }

        public bool Existe(int id)
        {
            return _dbEntidade.Any(x => x.Id == id);
        }

        public IQueryable<T> Listar()
        {
            return _dbEntidade.AsQueryable();
        }

        public void Remover(T entidade)
        {
            _dbEntidade.Remove(entidade);    
        }

        public void Remover(int id)
        {
            var entidade = Buscar(id);

            Remover(entidade);
        }
    }
}
