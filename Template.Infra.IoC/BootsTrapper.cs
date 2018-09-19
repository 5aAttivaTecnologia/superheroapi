using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Data;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Data.Repositories;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Entities;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Interfaces.Repositories;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Interfaces.Services;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Interfaces.UoW;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.Services;
using Template.Cadastro.Infra.CrossCutting.Autenticacao.UoW;
using Template.Cadastro.Infra.Data.Context;
using Template.Cadastro.Infra.Data.Repositories;
using Template.Cadastro.Infra.Data.UoW;
using Template.Core.Domain.Entities;
using Template.Core.Domain.Events;
using Template.Core.Domain.Handlers;
using Template.Core.Domain.Interfaces;
using Template.Domain.Interfaces.Repositories;
using Template.Domain.Interfaces.Services;
using Template.Domain.Interfaces.UoW;
using Template.Domain.Service;

namespace Template.Cadastro.Infra.CrossCutting.IoC
{
    public sealed class BootsTrapper
    {
        public static void Registrar(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUnitOfWorkCadastro, UnitOfWorkCadastro>();
            services.AddScoped<IUnitOfWorkAutenticacao, UnitOfWorkAutenticacao>();
            services.AddScoped<TemplateContext>();
            services.AddScoped<AutenticacaoContext>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddScoped<IHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IUsuario, AspNetUser>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
