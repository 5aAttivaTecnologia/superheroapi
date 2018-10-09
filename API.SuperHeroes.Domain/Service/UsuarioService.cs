using API.SuperHeroes.Domain.DTO;
using API.SuperHeroes.Domain.Events;
using API.SuperHeroes.Domain.Interfaces;
using API.SuperHeroes.Domain.Interfaces.Repositories;
using API.SuperHeroes.Domain.Interfaces.Services;
using API.SuperHeroes.Domain.Interfaces.UoW;
using System.Linq;

namespace API.SuperHeroes.Domain.Service
{
    public sealed class UsuarioService : Base.Service<UsuarioService>, IUsuarioService
    {
        readonly IUsuarioRepository _usuariorepository;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            IHandler<DomainNotification> domainNotification,
            IUnitOfWorkSuperheroes unitOfWorkSuperheroes,
            IUnitOfWorkUsuario unitOfWorkUsuario)
            : base(domainNotification, unitOfWorkSuperheroes, unitOfWorkUsuario)
        {
            _usuariorepository = usuarioRepository;
        }

            
        public UsuarioDTO ObterUsuarioPorCPF(string nrcpf)
        {
            var objusuario = _usuariorepository.ObterUsuarioPorCPF(nrcpf).FirstOrDefault();

            return objusuario;
        }
    }
}
