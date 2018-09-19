using AutoMapper;
using Template.Cadastro.Api.ViewModels;
using Template.Cadastro.Domain.Entities;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Entities;

namespace Template.Cadastro.Api.Mapper
{
    public class ViewModelToModel: Profile
    {
        public ViewModelToModel()
        {
            CreateMap<TemplateViewModel, TemplateEntidade>();
            CreateMap<LoginViewModel, Usuario>();
        }
    }
}
