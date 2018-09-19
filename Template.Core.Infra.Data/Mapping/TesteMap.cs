using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Core.Domain.Entities;
using Template.Core.Infra.Data.Extensions;

namespace Template.Core.Infra.Data.Mapping
{
    class TesteMap : EntityTypeConfiguration<Teste>
    {
        public override void Map(EntityTypeBuilder<Teste> builder)
        {
            //builder.
        }
    }
}
