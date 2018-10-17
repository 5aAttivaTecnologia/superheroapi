using API.SuperHeroes.Domain.Entidade;
using API.SuperHeroes.Domain.Events;
using API.SuperHeroes.Domain.Interfaces;
using API.SuperHeroes.Domain.Interfaces.Repositories;
using API.SuperHeroes.Domain.Interfaces.Services;
using API.SuperHeroes.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace API.SuperHeroes.Domain.Service
{
    public sealed class SuperheroeService : Base.Service<Superheroe>, ISuperheroeService
    {
        readonly ISuperheroeRepository _superheroeRepository;
        readonly IUsuarioRepository _usuarioRepository;

        public SuperheroeService(
            ISuperheroeRepository superheroeRepository,
            IUsuarioRepository usuariorepository,
            IHandler<DomainNotification> domainNotification,
            IUnitOfWorkSuperheroes unitOfWorkSuperheroes)
            : base(domainNotification, unitOfWorkSuperheroes, usuariorepository)
        {
            _superheroeRepository = superheroeRepository;
            _usuarioRepository = usuariorepository;
        }



        public Superheroe ObterSuperheroeCompletoPorId(int superheroId, string token)
        {
            var personagem = _superheroeRepository.ObterSuperheroeCompltoPorId(superheroId).FirstOrDefault();

            if (personagem == null)
                return personagem;

            var pathImagem = $"{Directory.GetCurrentDirectory()}\\..\\imagens\\";

            personagem.Im_superheroe = File.Exists($"{pathImagem}{personagem.Id_superheroe}.jpg")
                ? File.ReadAllBytes($"{pathImagem}{personagem.Id_superheroe}.jpg")
                : File.ReadAllBytes($"{pathImagem}default.jpg");

            return personagem;
        }

        public List<Superheroe> ObterSuperheroesCompletoPorNome(string nome, string token)
        {
            var listapersonagens = _superheroeRepository.ObterSuperheroesCompltoPorNome(nome).ToList();

            if (listapersonagens == null)
                return listapersonagens;

            foreach (Superheroe personagem in listapersonagens)
            {
                var pathImagem = $"{Directory.GetCurrentDirectory()}\\..\\imagens\\";

                personagem.Im_superheroe = File.Exists($"{pathImagem}{personagem.Id_superheroe}.jpg")
                    ? File.ReadAllBytes($"{pathImagem}{personagem.Id_superheroe}.jpg")
                    : File.ReadAllBytes($"{pathImagem}default.jpg");
            }


            return listapersonagens;
        }

        public List<Superheroe> ObterListaSuperHeoresPaginada(string nome, int pagina, int nrpagina, string token)
        {
            
            if (nrpagina == 0)
                nrpagina = 9;

            List<Superheroe> listapersonagens = _superheroeRepository.ObterListaSuperHeoresPaginada(nome, pagina, nrpagina).ToList();

                if (listapersonagens == null)
                    return listapersonagens;

                foreach (Superheroe personagem in listapersonagens)
                {
                    var pathImagem = $"{Directory.GetCurrentDirectory()}\\..\\imagens\\";

                    personagem.Im_superheroe = File.Exists($"{pathImagem}{personagem.Id_superheroe}.jpg")
                        ? File.ReadAllBytes($"{pathImagem}{personagem.Id_superheroe}.jpg")
                        : File.ReadAllBytes($"{pathImagem}default.jpg");
                }   

            return listapersonagens;
        }

        public bool ValidaTokenAttribute(string token)
        {
            bool validado = false;

            Usuario usuario_token = _usuarioRepository.BuscaToken(token).FirstOrDefault();

            if (usuario_token == null)
                return validado;
                
            if(usuario_token.Id_Hash_autorização.Equals(token) && 
               usuario_token.Dt_Atualizacao_HasH_Autenticacao.Month.Equals(DateTime.Now.Month))
            {
                validado = true;
            }


            return validado;
        }

    }
}
