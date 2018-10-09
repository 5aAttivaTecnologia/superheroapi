using API.SuperHeroes.Domain.Entidade;
using API.SuperHeroes.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.SuperHeroes.Infra.Data.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public override void Map(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tbl_usuario_autenticacao")
               .HasKey(t => t.Nr_CPF);

            builder.Property(t => t.Nr_CPF)
                .HasColumnName("nr_cpf")
                .HasColumnType("varchar")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(t => t.Id_Hash_autorização)
                .HasColumnName("id_hash_autenticacao")
                .HasColumnType("varchar")
                .HasMaxLength(30);

            builder.Property(t => t.Dt_Atualizacao_HasH_Autenticacao)
                .HasColumnName("dt_atualizacao_hash_autenticacao")
                .HasColumnType("datetime");
        }
    }
}
