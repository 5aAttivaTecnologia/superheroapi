using API.SuperHeroes.Domain.Entidade;
using API.SuperHeroes.Domain.Interfaces.Repositories;
using API.SuperHeroes.Domain.Interfaces.UoW;
using API.SuperHeroes.Infra.Data.Context;
using API.SuperHeroes.Infra.Data.UoW;
using System.Linq;

namespace API.SuperHeroes.Infra.Data.Repositories
{
    public sealed class UsuarioRepository
        : Base.Repository<Usuario>, IUsuarioRepository
    {
        public SuperheroeContext _usuarioContext { get => (SuperheroeContext)_context; }

        public UsuarioRepository(SuperheroeContext usuarioContext, IUnitOfWorkSuperheroes unitOfWorkSuperheroes)
            : base(usuarioContext, unitOfWorkSuperheroes)
        {
        }

        public IQueryable<Usuario> ObterUsuarioPorCPF(string nrcpf)
        {
            return from x in _usuarioContext.Usuario
                   where x.Nr_CPF.Equals(nrcpf)
                   select new Usuario
                   {
                       Nr_CPF = x.Nr_CPF,
                       Id_Hash_autorização = x.Id_Hash_autorização,
                       Dt_Atualizacao_HasH_Autenticacao = x.Dt_Atualizacao_HasH_Autenticacao
                   };
        }

        public void CadastraUsuario(Usuario nrcpf)
        {
            _usuarioContext.Add(nrcpf);

            UnitOfWorkSuperheroes unit = new UnitOfWorkSuperheroes(_usuarioContext);
            unit.Commit();
        }

        public void AtualizaHash(Usuario usuario)
        {
            _usuarioContext.Update(usuario);

            UnitOfWorkSuperheroes unit = new UnitOfWorkSuperheroes(_usuarioContext);
            unit.Commit();
        }

        public IQueryable<Usuario> BuscaToken(string token)
        {
            return from x in _usuarioContext.Usuario
                   where x.Id_Hash_autorização.Equals(token)
                   select new Usuario
                   {
                       Nr_CPF = x.Nr_CPF,
                       Id_Hash_autorização = x.Id_Hash_autorização,
                       Dt_Atualizacao_HasH_Autenticacao = x.Dt_Atualizacao_HasH_Autenticacao
                   };
        }

        public IQueryable<Usuario> ListaUsuarios()
        {
            return from x in _usuarioContext.Usuario
                   select new Usuario
                   {
                       Nr_CPF = x.Nr_CPF,
                       Id_Hash_autorização = x.Id_Hash_autorização,
                       Dt_Atualizacao_HasH_Autenticacao = x.Dt_Atualizacao_HasH_Autenticacao
                   };
        }
    }
}
