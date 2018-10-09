using API.SuperHeroes.Domain.Entidade;
using API.SuperHeroes.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.SuperHeroes.Infra.Data.Mapping
{
    public class SuperheroeMap : EntityTypeConfiguration<Superheroe>
    {
        public override void Map(EntityTypeBuilder<Superheroe> builder)
        {
            builder.ToTable("tbl_superheroe")
                .HasKey(t => t.Id_superheroe);

            builder.Property(t => t.Id_superheroe)
                .HasColumnName("id_superheroe")
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(t => t.Nm_superheroe)
                .HasColumnName("nm_superheroe")
                .HasColumnType("varchar")
                .HasMaxLength(200);

            builder.Property(t => t.Ds_superheroe)
                .HasColumnName("ds_superheroe")
                .HasColumnType("varchar");

            builder.Property(t => t.St_ativo)
                .HasColumnName("st_ativo")
                .HasColumnType("varchar")
                .HasMaxLength(1);

        }
    }
}
