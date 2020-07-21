using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Puc.Minas.Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Puc.Minas.Banking.Context.Mapping
{
    public class ContaCorrenteMap : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.ToTable("CONTA_CORRENTE");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_CONTA_CORRENTE");

            builder.Property(o => o.IdCorrentista)
                .IsRequired()
                .HasColumnName("ID_CORRENTISTA");

            builder.Property(o => o.Numero)
                .IsRequired()
                .HasColumnName("NUMERO_CONTA");

            builder.Property(o => o.Digito)
                .IsRequired()
                .HasColumnName("DIGITO_CONTA");

            builder.Property(o => o.LimiteCredito)
                .IsRequired()
                .HasColumnName("LIMITE_CREDITO");

            builder.Ignore(o => o.Saldo);

            builder.HasOne(o => o.Correntista)
                .WithMany(o => o.ContaCorrentes)
                .HasForeignKey(o => o.IdCorrentista);

            builder.HasMany(o => o.Movimentacoes)
                .WithOne(o => o.ContaCorrente)
                .HasForeignKey(o => o.IdContaCorrente);
        }
    }
}
