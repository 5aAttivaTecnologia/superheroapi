using API.SuperHeroes.Domain.Entidade;
using API.SuperHeroes.Domain.Events;
using API.SuperHeroes.Domain.Interfaces;
using API.SuperHeroes.Domain.Interfaces.Repositories;
using API.SuperHeroes.Domain.Interfaces.Services;
using API.SuperHeroes.Domain.Interfaces.UoW;
using System;
using System.Linq;

namespace API.SuperHeroes.Domain.Service
{
    public sealed class UsuarioService : Base.Service<UsuarioService>, IUsuarioService
    {
        readonly IUsuarioRepository _usuariorepository;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            IHandler<DomainNotification> domainNotification,
            IUnitOfWorkSuperheroes unitOfWorkSuperheroes)
            : base(domainNotification, unitOfWorkSuperheroes)
        {
            _usuariorepository = usuarioRepository;
        }

            
        public Usuario ObterUsuarioPorCPF(string nrcpf)
        {
            var objusuario = _usuariorepository.ObterUsuarioPorCPF(nrcpf).FirstOrDefault();

            if (objusuario == null)
                //cadastrar o usuariopelo cpf e devolver os dados dele
                return CadastraUsuario(nrcpf);
            else
                return AtualizaHash(objusuario);            
        }

        private Usuario AtualizaHash(Usuario objusuario)
        {
            objusuario.Id_Hash_autorização = alfanumericoAleatorio(30);
            objusuario.Dt_Atualizacao_HasH_Autenticacao = DateTime.Now;

            _usuariorepository.AtualizaHash(objusuario);

            return objusuario;
        }

        public Usuario CadastraUsuario(string nrcpf)
        {
            

            Usuario newobj = new Usuario();
            newobj.Nr_CPF = nrcpf;
            newobj.Id_Hash_autorização = alfanumericoAleatorio(30);
            newobj.Dt_Atualizacao_HasH_Autenticacao = DateTime.Now;

            _usuariorepository.CadastraUsuario(newobj);

            return newobj;           
        }

        public string alfanumericoAleatorio(int tamanho)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
       
    }
}
