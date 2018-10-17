using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Eventos.IO.Services.Api.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                //Implementação do documento da api swagger
                //string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
                //string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
                //string caminhoDocumentacao = Path.Combine(caminhoAplicacao, $"{ nomeAplicacao}.xml");

                //s.IncludeXmlComments(caminhoDocumentacao);

                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "API Teste Front End SuperHeroes",
                    Description = "API para teste de Front End 5A Attiva.",
                    TermsOfService = "Nenhum",
                    Contact = new Contact { Name = "", Email = "", Url = "http://localhost:" },
                    License = new License { Name = "", Url = "http://www.google.com.br" }
                });

                //s.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });

            //services.ConfigureSwaggerGen(opt =>
            //{
            //    opt.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            //});
        }
    }
}