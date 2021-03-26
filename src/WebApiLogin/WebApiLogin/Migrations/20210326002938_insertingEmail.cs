using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiLogin.Migrations
{
    public partial class insertingEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UsuarioModel",
                maxLength: 80,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UsuarioModel");
        }
    }
}
