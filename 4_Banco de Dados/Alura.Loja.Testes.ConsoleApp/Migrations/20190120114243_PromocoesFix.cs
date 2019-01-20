using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.Loja.Testes.ConsoleApp.Migrations
{
    public partial class PromocoesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromocaoProdutos_Promocao_PromocaoId",
                table: "PromocaoProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promocao",
                table: "Promocao");

            migrationBuilder.RenameTable(
                name: "Promocao",
                newName: "Promocoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promocoes",
                table: "Promocoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PromocaoProdutos_Promocoes_PromocaoId",
                table: "PromocaoProdutos",
                column: "PromocaoId",
                principalTable: "Promocoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromocaoProdutos_Promocoes_PromocaoId",
                table: "PromocaoProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promocoes",
                table: "Promocoes");

            migrationBuilder.RenameTable(
                name: "Promocoes",
                newName: "Promocao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promocao",
                table: "Promocao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PromocaoProdutos_Promocao_PromocaoId",
                table: "PromocaoProdutos",
                column: "PromocaoId",
                principalTable: "Promocao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
