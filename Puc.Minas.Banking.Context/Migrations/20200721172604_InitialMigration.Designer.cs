﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Puc.Minas.Banking.Context.Context;

namespace Puc.Minas.Banking.Context.Migrations
{
    [DbContext(typeof(PucMinasBankingContext))]
    [Migration("20200721172604_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("Puc.Minas.Banking.Domain.Entity.Coaf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_COAF")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdMovimentacao")
                        .HasColumnName("ID_MOVIMENTACAO")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdMovimentacao")
                        .IsUnique();

                    b.ToTable("COAF");
                });

            modelBuilder.Entity("Puc.Minas.Banking.Domain.Entity.ContaCorrente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_CONTA_CORRENTE")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Digito")
                        .HasColumnName("DIGITO_CONTA")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdCorrentista")
                        .HasColumnName("ID_CORRENTISTA")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("LimiteCredito")
                        .HasColumnName("LIMITE_CREDITO")
                        .HasColumnType("TEXT");

                    b.Property<int>("Numero")
                        .HasColumnName("NUMERO_CONTA")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdCorrentista");

                    b.ToTable("CONTA_CORRENTE");
                });

            modelBuilder.Entity("Puc.Minas.Banking.Domain.Entity.Correntista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_CORRENTISTA")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnName("TELEFONE")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CORRENTISTA");
                });

            modelBuilder.Entity("Puc.Minas.Banking.Domain.Entity.Movimentacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_MOVIMENTACAO")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataMovimentacao")
                        .HasColumnName("DATA_MOVIMENTACAO")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdContaCorrente")
                        .HasColumnName("ID_CONTA_CORRENTE")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IdUltimaMovimentacao")
                        .HasColumnName("ID_ULTIMA_MOVIMENTACAO")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Operacao")
                        .HasColumnName("OPERACAO")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("UltimoSaldo")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Valor")
                        .HasColumnName("VALOR")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdContaCorrente");

                    b.HasIndex("IdUltimaMovimentacao");

                    b.ToTable("MOVIMENTACAO");
                });

            modelBuilder.Entity("Puc.Minas.Banking.Domain.Entity.Coaf", b =>
                {
                    b.HasOne("Puc.Minas.Banking.Domain.Entity.Movimentacao", "Movimentacao")
                        .WithOne("Coaf")
                        .HasForeignKey("Puc.Minas.Banking.Domain.Entity.Coaf", "IdMovimentacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Puc.Minas.Banking.Domain.Entity.ContaCorrente", b =>
                {
                    b.HasOne("Puc.Minas.Banking.Domain.Entity.Correntista", "Correntista")
                        .WithMany("ContaCorrentes")
                        .HasForeignKey("IdCorrentista")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Puc.Minas.Banking.Domain.Entity.Correntista", b =>
                {
                    b.OwnsOne("Puc.Minas.Banking.Domain.ValueObject.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("CorrentistaId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Bairro")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Cep")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Cidade")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Complemento")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Estado")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Logradouro")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Numero")
                                .HasColumnType("TEXT");

                            b1.HasKey("CorrentistaId");

                            b1.ToTable("CORRENTISTA");

                            b1.WithOwner()
                                .HasForeignKey("CorrentistaId");
                        });
                });

            modelBuilder.Entity("Puc.Minas.Banking.Domain.Entity.Movimentacao", b =>
                {
                    b.HasOne("Puc.Minas.Banking.Domain.Entity.ContaCorrente", "ContaCorrente")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("IdContaCorrente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Puc.Minas.Banking.Domain.Entity.Movimentacao", "UltimaMovimentacao")
                        .WithMany()
                        .HasForeignKey("IdUltimaMovimentacao");
                });
#pragma warning restore 612, 618
        }
    }
}
