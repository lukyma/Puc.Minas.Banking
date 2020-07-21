using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Puc.Minas.Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Puc.Minas.Banking.Context.Mapping
{
    public class CorrentistaMap : IEntityTypeConfiguration<Correntista>
    {
        public void Configure(EntityTypeBuilder<Correntista> builder)
        {
            builder.ToTable("CORRENTISTA");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_CORRENTISTA");

            builder.Property(o => o.Cpf)
                .IsRequired()
                .HasColumnName("CPF");

            builder.Property(o => o.Nome)
                .IsRequired()
                .HasColumnName("NOME");

            builder.Property(o => o.Telefone)
                .IsRequired()
                .HasColumnName("TELEFONE");

            builder.OwnsOne(o => o.Endereco, a =>
                {
                    a.WithOwner();
                });
        }
    }
}
