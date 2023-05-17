using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Funcoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuncaoUsuario_Funcao_FuncoesId",
                table: "FuncaoUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcao",
                table: "Funcao");

            migrationBuilder.RenameTable(
                name: "Funcao",
                newName: "Funcoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcoes",
                table: "Funcoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FuncaoUsuario_Funcoes_FuncoesId",
                table: "FuncaoUsuario",
                column: "FuncoesId",
                principalTable: "Funcoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuncaoUsuario_Funcoes_FuncoesId",
                table: "FuncaoUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcoes",
                table: "Funcoes");

            migrationBuilder.RenameTable(
                name: "Funcoes",
                newName: "Funcao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcao",
                table: "Funcao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FuncaoUsuario_Funcao_FuncoesId",
                table: "FuncaoUsuario",
                column: "FuncoesId",
                principalTable: "Funcao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
