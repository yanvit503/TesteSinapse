using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteSinapse.Migrations
{
    public partial class ClienteVisivel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Visivel",
                table: "Clientes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visivel",
                table: "Clientes");
        }
    }
}
