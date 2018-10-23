using API.SuperHeroes.Domain.Entidade;
using API.SuperHeroes.Domain.Interfaces.Repositories;
using API.SuperHeroes.Domain.Interfaces.UoW;
using API.SuperHeroes.Domain.Service;
using API.SuperHeroes.Domain.Handlers;
using Bogus;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace API.SuperHeroes.Test
{
    public class UsuarioTest
    {
        public UsuarioService _usuarioservice;

        public Mock<IUnitOfWorkSuperheroes> _uow;
        public Mock<IUsuarioRepository> _usuariorepository;

        public List<Usuario> lusuarios;

        public Usuario _usuario;
        public string hashtest;
        public string hashtestup;
        public DateTime dthash;
        public DateTime dthashaut;
        public string cpf;
        public string othercpf;
        public string usuariocpf;

        public Random _random;        

        public UsuarioTest()
        {
            _usuariorepository = new Mock<IUsuarioRepository>();
            _uow = new Mock<IUnitOfWorkSuperheroes>();
            _usuarioservice = new UsuarioService(_usuariorepository.Object, new DomainNotificationHandler(), _uow.Object);

            hashtest = "1c2d5f6d3t4h7d8r9h6j5l4s1x2c3f";
            hashtestup = "1c2d5f6d3t4h7d8r9h6j5l4s1x2c00";

            dthash = DateTime.Now;
            dthashaut = DateTime.Now.AddDays(1);
            cpf = "22233344455";
            othercpf = "33344455566";
            _random = new Random();

            
            ObterObjetos();
            SetupTestes();

        }


        [Fact]
        public void ObterUsuarioPorCPFTest()
        {
            Usuario user = _usuarioservice.ObterUsuarioPorCPF(cpf);

            Assert.Equal(cpf, user.Nr_CPF);
        }

        [Fact]
        public void AtualizaHashTest()
        {
            Usuario user = _usuarioservice.ObterUsuarioPorCPF(cpf);

            Assert.NotEqual(user.Id_Hash_autorização, hashtest);
        }

        [Fact]
        public void CadastraUsuarioTest()
        {
            Usuario user = _usuarioservice.CadastraUsuario(othercpf);

            Assert.NotNull(user);
        }

        [Fact]
        public void alfanumericoAleatorioTest()
        {
            string hash = _usuarioservice.alfanumericoAleatorio(30);

            Assert.Equal(30, hash.Length);
        }

        [Fact]
        public void ListaUsuariosTes()
        {
            List<Usuario> list = _usuarioservice.ListaUsuarios();

            Assert.NotNull(list);

        }

        public void SetupTestes()
        {
            _usuariorepository.Setup(x => x.ObterUsuarioPorCPF(cpf)).Returns(lusuarios.AsQueryable());
            _usuariorepository.Setup(x => x.ListaUsuarios()).Returns(lusuarios.AsQueryable());
        }

        public void ObterObjetos()
        {
            _usuario = new Faker<Usuario>()
                .RuleFor(b => b.Nr_CPF, f => cpf)
                .RuleFor(b => b.Id_Hash_autorização, f => hashtest)
                .RuleFor(b => b.Dt_Atualizacao_HasH_Autenticacao, f => dthash);

            lusuarios = new List<Usuario>();
            lusuarios.Add(_usuario);

        }
    }
}
