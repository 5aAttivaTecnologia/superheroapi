using Microsoft.Extensions.DependencyInjection;
using Template.Cadastro.Infra.CrossCutting.IoC;

namespace Template.Cadastro.Api.Configuracoes
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            BootsTrapper.Registrar(services);
        }
    }
}