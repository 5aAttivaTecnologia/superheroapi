using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace Eventos.IO.Services.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Template API",
                    Description = "API do site Template",
                    TermsOfService = "Nenhum",
                    Contact = new Contact { Name = "Desenvolvedor Paulo Felipe", Email = "paulo.felipe@outlook.com", Url = "http://localhost:" },
                    License = new License { Name = "MIT", Url = "http://www.google.com.br" }
                });

                s.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });

            services.ConfigureSwaggerGen(opt =>
            {
                opt.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });
        }
    }
}