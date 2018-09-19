using AutoMapper;
using Template.Cadastro.Api.ViewModels;
using Template.Cadastro.Domain.Entities;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Entities;

namespace Template.Cadastro.Api.Mapper
{
    public class ModelToViewModel: Profile
    {
        public ModelToViewModel()
        {
            CreateMap<TemplateEntidade, TemplateViewModel>();
            CreateMap<Usuario, LoginViewModel>();
        }
    }
}
