using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Puc.Minas.Banking.Context.Mapping;
using Puc.Minas.Banking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Puc.Minas.Banking.Context.Context
{
    public class PucMinasBankingContext : DbContext
    {
        public PucMinasBankingContext(DbContextOptions<PucMinasBankingContext> options) : base(options)
        {
        }

        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<Correntista> Correntista { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }
        public DbSet<Coaf> Coaf { get; set; }
        //public DbSet<UltimaMovimentacao> UltimaMovimentacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CorrentistaMap());
            modelBuilder.ApplyConfiguration(new ContaCorrenteMap());
            modelBuilder.ApplyConfiguration(new MovimentacaoMap());
            modelBuilder.ApplyConfiguration(new CoafMap());
            //modelBuilder.ApplyConfiguration(new UltimaMovimentacaoMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
