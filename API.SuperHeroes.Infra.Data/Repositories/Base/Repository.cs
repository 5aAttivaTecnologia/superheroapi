using API.SuperHeroes.Domain.Entidade.Base;
using API.SuperHeroes.Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.SuperHeroes.Infra.Data.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T> where T : Entidade<T>
    {
        readonly protected DbContext _context;
        readonly DbSet<T> _dbEntidade;

        protected Repository(DbContext context)
        {
            _context = context;
            _dbEntidade = _context.Set<T>();
        }

        public void Adicionar(T entidade)
        {
            _dbEntidade.Add(entidade);
        }

        public void Alterar(T entidade)
        {
            _dbEntidade.Update(entidade);
        }

        public T Buscar(int id)
        {
            return _dbEntidade.Find(id);
        }

        public void Excluir(int id)
        {
            Excluir(Buscar(id));
        }

        public void Excluir(T entidade)
        {
            _dbEntidade.Remove(entidade);
        }

        public IQueryable<T> Listar()
        {
            return _dbEntidade;
        }
    }
}
