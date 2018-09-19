using System;
using Template.Cadastro.Domain.Entities;
using Template.Core.Domain.Events;
using Template.Core.Domain.Interfaces;
using Template.Core.Infra.Data.Interfaces.UoW;
using Template.Domain.Interfaces.Repositories;
using Template.Domain.Interfaces.Services;
using Template.Domain.Interfaces.UoW;

namespace Template.Domain.Service
{
    public sealed class TemplateService : Template.Core.Domain.Services.Base.Service<TemplateEntidade>, ITemplateService
    {
        ITemplateRepository _templateRepository;

        public TemplateService(ITemplateRepository templateRepository,
                               IHandler<DomainNotification> domainNotification,
                               IUnitOfWorkCadastro unitOfWork
                              )
            : base(domainNotification, unitOfWork)
        {
            _templateRepository = templateRepository;
        }

        public TemplateEntidade Alterar(TemplateEntidade template)
        {
            if (!VerificarEntidade(template))
                return template;

            //aqui alguma regra de negócio

            template.DataAlteracao = DateTime.Now;

            _templateRepository.Atualizar(template);

            Commit("Ocorreu um erro ao tentar alterar o template");

            return template;
        }

        public TemplateEntidade Cadastrar(TemplateEntidade template)
        {
            if (!VerificarEntidade(template))
                return template;

            //aqui alguma regra de negócio

            template.DataInclusao = DateTime.Now;

            _templateRepository.Adicionar(template);

            Commit("Ocorreu um erro ao tentar cadastrar o template");

            return template;
        }

        public void Remover(int id)
        {
            _templateRepository.Remover(id);

            Commit("Ocorreu um erro ao tentar remover o template");
        }
    }
}
