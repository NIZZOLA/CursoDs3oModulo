using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API01.Etec.Migrations
{
    public partial class InclusaoEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Nascimento",
                table: "ContatoModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nascimento",
                table: "ContatoModel");
        }
    }
}
