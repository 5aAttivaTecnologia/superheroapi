using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Cadastro.Domain.Entities;
using Template.Core.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Template.Cadastro.Infra.Data.Mapping
{
    public sealed class TemplateMap : EntityTypeConfiguration<TemplateEntidade>
    {
        public override void Map(EntityTypeBuilder<TemplateEntidade> builder)
        {

            builder.ToTable("TEMPLATE")
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("ID")
                .HasColumnType("int");

            builder.Property(x => x.Nome)
                .HasColumnName("NOME")
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder
                .Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .Property(x => x.DataInclusao)
                .HasColumnType("datetime2")
                .HasColumnName("DATA_INC")
                .IsRequired();

            builder
                .Property(x => x.DataAlteracao)
                .HasColumnType("datetime2")
                .HasColumnName("DATA_ALT");

            builder
                .Property(x => x.Ativo)
                .HasColumnType("bit")
                .HasColumnName("ATIVO")
                .IsRequired();

            builder
                .Property(x => x.IdUsuario)
                .HasColumnType("bit")
                .HasColumnName("ID_USUARIO");

            //builder.Ignore(e => e.ValidationResult);

            //builder.Ignore(e => e.CascadeMode);

            //builder.ToTable("Categorias");
        }
    }
}
