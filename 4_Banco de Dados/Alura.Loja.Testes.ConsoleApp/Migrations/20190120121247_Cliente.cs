using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Alura.Loja.Testes.ConsoleApp.Migrations
{
    public partial class Cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromocaoProdutos_Produtos_ProdutoId",
                table: "PromocaoProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_PromocaoProdutos_Promocoes_PromocaoId",
                table: "PromocaoProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PromocaoProdutos",
                table: "PromocaoProdutos");

            migrationBuilder.RenameTable(
                name: "PromocaoProdutos",
                newName: "PromocaoProduto");

            migrationBuilder.RenameIndex(
                name: "IX_PromocaoProdutos_PromocaoId",
                table: "PromocaoProduto",
                newName: "IX_PromocaoProduto_PromocaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PromocaoProduto",
                table: "PromocaoProduto",
                columns: new[] { "ProdutoId", "PromocaoId" });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Rua = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Enderecos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PromocaoProduto_Produtos_ProdutoId",
                table: "PromocaoProduto",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromocaoProduto_Promocoes_PromocaoId",
                table: "PromocaoProduto",
                column: "PromocaoId",
                principalTable: "Promocoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromocaoProduto_Produtos_ProdutoId",
                table: "PromocaoProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_PromocaoProduto_Promocoes_PromocaoId",
                table: "PromocaoProduto");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PromocaoProduto",
                table: "PromocaoProduto");

            migrationBuilder.RenameTable(
                name: "PromocaoProduto",
                newName: "PromocaoProdutos");

            migrationBuilder.RenameIndex(
                name: "IX_PromocaoProduto_PromocaoId",
                table: "PromocaoProdutos",
                newName: "IX_PromocaoProdutos_PromocaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PromocaoProdutos",
                table: "PromocaoProdutos",
                columns: new[] { "ProdutoId", "PromocaoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PromocaoProdutos_Produtos_ProdutoId",
                table: "PromocaoProdutos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromocaoProdutos_Promocoes_PromocaoId",
                table: "PromocaoProdutos",
                column: "PromocaoId",
                principalTable: "Promocoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
