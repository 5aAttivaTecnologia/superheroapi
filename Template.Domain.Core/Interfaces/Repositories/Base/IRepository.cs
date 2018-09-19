using System.Linq;
using Template.Core.Domain.Entities.Base;

namespace Template.Core.Domain.Interfaces.Repositories.Base
{
    public interface IRepository<T> where T : Entidade<T>
    {
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Remover(T entidade);
        void Remover(int id);
        bool Existe(int id);
        T Buscar(int id);
        IQueryable<T> Listar(); 
    }
}
