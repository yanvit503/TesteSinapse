using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteSinapse.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Cod_Cliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Data_Cadastro = table.Column<DateTime>(nullable: false),
                    Tipo_Cliente = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Cod_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "Faturas",
                columns: table => new
                {
                    Num_Fatura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_Cliente = table.Column<int>(nullable: false),
                    Data_Emissao = table.Column<DateTime>(nullable: false),
                    Data_Vencimento = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturas", x => x.Num_Fatura);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Faturas");
        }
    }
}
