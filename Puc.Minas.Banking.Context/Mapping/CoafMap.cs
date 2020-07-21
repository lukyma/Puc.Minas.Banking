using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Puc.Minas.Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Puc.Minas.Banking.Context.Mapping
{
    public class CoafMap : IEntityTypeConfiguration<Coaf>
    {
        public void Configure(EntityTypeBuilder<Coaf> builder)
        {
            builder.ToTable("COAF");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_COAF");

            builder.Property(o => o.IdMovimentacao)
                .IsRequired()
                .HasColumnName("ID_MOVIMENTACAO");
        }
    }
}
