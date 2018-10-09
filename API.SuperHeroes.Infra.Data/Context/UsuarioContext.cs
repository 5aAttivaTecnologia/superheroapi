using API.SuperHeroes.Domain.Entidade;
using API.SuperHeroes.Infra.Data.Extensions;
using API.SuperHeroes.Infra.Data.Mapping;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace API.SuperHeroes.Infra.Data.Context
{
    public sealed class UsuarioContext : DbContext
    {
        private readonly IHostingEnvironment _env;

        public DbSet<Usuario> Usuario { get; set; }

        public UsuarioContext(IHostingEnvironment env)
        {
            _env = env;
        }

        public void MappingRepositoryModels(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new UsuarioMap());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MappingRepositoryModels(modelBuilder);

            //removendo comportamento cascade delete
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                                .SelectMany(t => t.GetForeignKeys())
                                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true)
                .Build();

            //optionsBuilder.UseOracle(config.GetConnectionString("OracleConnectionString"));
            optionsBuilder.UseSqlServer(config.GetConnectionString("OracleConnectionString"));
        }
    }
}
