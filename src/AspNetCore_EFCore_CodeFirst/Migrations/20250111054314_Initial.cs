using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCore_EFCore_CodeFirst.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    CategoriaID = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(150)", nullable: false),
                    Autor = table.Column<string>(type: "varchar(150)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Livro_Categoria_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categoria",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "ID", "Nome" },
                values: new object[] { 1, "Poesia" });

            migrationBuilder.InsertData(
                table: "Livro",
                columns: new[] { "ID", "Autor", "CategoriaID", "DataEntrada", "Preco", "Quantidade", "Titulo" },
                values: new object[,]
                {
                    { 1, "Manoel de Barros", 1, new DateTime(2025, 1, 11, 1, 43, 14, 21, DateTimeKind.Local).AddTicks(5842), 25.00m, 10, "O Guardador de Águas" },
                    { 2, "Manoel de Barros", 1, new DateTime(2025, 1, 11, 1, 43, 14, 21, DateTimeKind.Local).AddTicks(5853), 25.00m, 16, "O Livro das Ignorãças" },
                    { 3, "Thiago de Mello", 1, new DateTime(2025, 1, 11, 1, 43, 14, 21, DateTimeKind.Local).AddTicks(5855), 25.00m, 54, "Faz escuro mais eu canto" },
                    { 4, "Orides Fontela", 1, new DateTime(2025, 1, 11, 1, 43, 14, 21, DateTimeKind.Local).AddTicks(5855), 25.00m, 22, "Poesia Completa" },
                    { 5, "Joseph Campbell", 1, new DateTime(2025, 1, 11, 1, 43, 14, 21, DateTimeKind.Local).AddTicks(5921), 25.00m, 10, "O Poder do Mito" },
                    { 6, "Thiago de Mello", 1, new DateTime(2025, 1, 11, 1, 43, 14, 21, DateTimeKind.Local).AddTicks(5922), 25.00m, 10, "Poesia comprometida com a minha e a tua vida" }
                });

            migrationBuilder.CreateIndex(
                name: "IDX_livro_Titulo",
                table: "Livro",
                column: "Titulo");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_CategoriaID",
                table: "Livro",
                column: "CategoriaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
