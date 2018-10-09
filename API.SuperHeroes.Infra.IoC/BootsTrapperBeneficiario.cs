using API.SuperHeroes.Domain.Events;
using API.SuperHeroes.Domain.Handlers;
using API.SuperHeroes.Domain.Interfaces;
using API.SuperHeroes.Domain.Interfaces.Repositories;
using API.SuperHeroes.Domain.Interfaces.Services;
using API.SuperHeroes.Domain.Interfaces.UoW;
using API.SuperHeroes.Domain.Service;
using API.SuperHeroes.Infra.Data.Context;
using API.SuperHeroes.Infra.Data.Repositories;
using API.SuperHeroes.Infra.Data.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace API.SuperHeroes.Infra.CrossCutting.IoC
{
    public static class BootsTrapperBeneficiario
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IUnitOfWorkSuperheroes, UnitOfWorkSuperheroes>();
            services.AddScoped<IUnitOfWorkUsuario, UnitOfWorkUsuario>();
            services.AddScoped<SuperheroeContext>();
            services.AddScoped<UsuarioContext>();

            //services
            services.AddScoped<ISuperheroeService, SuperheroeService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            //repositories
            services.AddScoped<ISuperheroeRepository, SuperheroeRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        }
    }
}
