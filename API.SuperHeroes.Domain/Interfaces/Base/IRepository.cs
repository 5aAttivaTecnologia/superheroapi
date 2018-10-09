using API.SuperHeroes.Domain.Entidade.Base;
using System.Linq;

namespace API.SuperHeroes.Domain.Interfaces.Base
{
    public interface IRepository<T> where T : Entidade<T>
    {
        void Adicionar(T entidade);
        void Alterar(T entidade);
        T Buscar(int id);
        IQueryable<T> Listar();
        void Excluir(int id);
        void Excluir(T entidade);
    }
}
