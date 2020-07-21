using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Puc.Minas.Banking.Context.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CORRENTISTA",
                columns: table => new
                {
                    ID_CORRENTISTA = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NOME = table.Column<string>(nullable: false),
                    CPF = table.Column<string>(nullable: false),
                    TELEFONE = table.Column<string>(nullable: false),
                    Endereco_Logradouro = table.Column<string>(nullable: true),
                    Endereco_Numero = table.Column<string>(nullable: true),
                    Endereco_Complemento = table.Column<string>(nullable: true),
                    Endereco_Cep = table.Column<string>(nullable: true),
                    Endereco_Bairro = table.Column<string>(nullable: true),
                    Endereco_Estado = table.Column<string>(nullable: true),
                    Endereco_Cidade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CORRENTISTA", x => x.ID_CORRENTISTA);
                });

            migrationBuilder.CreateTable(
                name: "CONTA_CORRENTE",
                columns: table => new
                {
                    ID_CONTA_CORRENTE = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID_CORRENTISTA = table.Column<int>(nullable: false),
                    NUMERO_CONTA = table.Column<int>(nullable: false),
                    DIGITO_CONTA = table.Column<int>(nullable: false),
                    LIMITE_CREDITO = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTA_CORRENTE", x => x.ID_CONTA_CORRENTE);
                    table.ForeignKey(
                        name: "FK_CONTA_CORRENTE_CORRENTISTA_ID_CORRENTISTA",
                        column: x => x.ID_CORRENTISTA,
                        principalTable: "CORRENTISTA",
                        principalColumn: "ID_CORRENTISTA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MOVIMENTACAO",
                columns: table => new
                {
                    ID_MOVIMENTACAO = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID_CONTA_CORRENTE = table.Column<int>(nullable: false),
                    ID_ULTIMA_MOVIMENTACAO = table.Column<int>(nullable: true),
                    VALOR = table.Column<decimal>(nullable: false),
                    DATA_MOVIMENTACAO = table.Column<DateTime>(nullable: false),
                    OPERACAO = table.Column<int>(nullable: false),
                    UltimoSaldo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVIMENTACAO", x => x.ID_MOVIMENTACAO);
                    table.ForeignKey(
                        name: "FK_MOVIMENTACAO_CONTA_CORRENTE_ID_CONTA_CORRENTE",
                        column: x => x.ID_CONTA_CORRENTE,
                        principalTable: "CONTA_CORRENTE",
                        principalColumn: "ID_CONTA_CORRENTE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MOVIMENTACAO_MOVIMENTACAO_ID_ULTIMA_MOVIMENTACAO",
                        column: x => x.ID_ULTIMA_MOVIMENTACAO,
                        principalTable: "MOVIMENTACAO",
                        principalColumn: "ID_MOVIMENTACAO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COAF",
                columns: table => new
                {
                    ID_COAF = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID_MOVIMENTACAO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COAF", x => x.ID_COAF);
                    table.ForeignKey(
                        name: "FK_COAF_MOVIMENTACAO_ID_MOVIMENTACAO",
                        column: x => x.ID_MOVIMENTACAO,
                        principalTable: "MOVIMENTACAO",
                        principalColumn: "ID_MOVIMENTACAO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COAF_ID_MOVIMENTACAO",
                table: "COAF",
                column: "ID_MOVIMENTACAO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_CORRENTE_ID_CORRENTISTA",
                table: "CONTA_CORRENTE",
                column: "ID_CORRENTISTA");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIMENTACAO_ID_CONTA_CORRENTE",
                table: "MOVIMENTACAO",
                column: "ID_CONTA_CORRENTE");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIMENTACAO_ID_ULTIMA_MOVIMENTACAO",
                table: "MOVIMENTACAO",
                column: "ID_ULTIMA_MOVIMENTACAO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COAF");

            migrationBuilder.DropTable(
                name: "MOVIMENTACAO");

            migrationBuilder.DropTable(
                name: "CONTA_CORRENTE");

            migrationBuilder.DropTable(
                name: "CORRENTISTA");
        }
    }
}
