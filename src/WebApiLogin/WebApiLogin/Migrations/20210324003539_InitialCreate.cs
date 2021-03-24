using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiLogin.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataDaInclusao = table.Column<DateTime>(nullable: false),
                    DataDaAlteracao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioModel");
        }
    }
}
