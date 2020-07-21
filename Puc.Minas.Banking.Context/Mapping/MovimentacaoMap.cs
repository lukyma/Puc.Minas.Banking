using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Puc.Minas.Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Puc.Minas.Banking.Context.Mapping
{
    public class MovimentacaoMap : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.ToTable("MOVIMENTACAO");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_MOVIMENTACAO");

            builder.Property(o => o.IdContaCorrente)
                .IsRequired()
                .HasColumnName("ID_CONTA_CORRENTE");

            builder.Property(o => o.IdUltimaMovimentacao)
               .IsRequired(false)
               .HasColumnName("ID_ULTIMA_MOVIMENTACAO");

            builder.Property(o => o.Operacao)
                .IsRequired()
                .HasColumnName("OPERACAO");

            builder.Property(o => o.Valor)
                .IsRequired()
                .HasColumnName("VALOR");

            builder.Property(o => o.DataMovimentacao)
                .IsRequired()
                .HasColumnName("DATA_MOVIMENTACAO");

            builder.HasOne(o => o.ContaCorrente)
                .WithMany(o => o.Movimentacoes)
                .HasForeignKey(o => o.IdContaCorrente);

            builder.HasOne(o => o.Coaf)
                .WithOne(o => o.Movimentacao)
                .HasForeignKey<Coaf>(o => o.IdMovimentacao);
        }
    }
}
