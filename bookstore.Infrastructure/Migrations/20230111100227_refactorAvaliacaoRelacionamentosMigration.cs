using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookstore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refactorAvaliacaoRelacionamentosMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroAvaliacoes");

            migrationBuilder.AddColumn<int>(
                name: "LivroId",
                table: "Avaliacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Perfis",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeCriacao",
                value: new DateTime(2023, 1, 11, 7, 2, 26, 969, DateTimeKind.Local).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Perfis",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataDeCriacao",
                value: new DateTime(2023, 1, 11, 7, 2, 26, 969, DateTimeKind.Local).AddTicks(5214));

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_LivroId",
                table: "Avaliacoes",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Livros_LivroId",
                table: "Avaliacoes",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Livros_LivroId",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_LivroId",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "LivroId",
                table: "Avaliacoes");

            migrationBuilder.CreateTable(
                name: "LivroAvaliacoes",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false),
                    LivroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAvaliacoes", x => new { x.AvaliacaoId, x.LivroId });
                    table.ForeignKey(
                        name: "FK_LivroAvaliacoes_Avaliacoes_AvaliacaoId",
                        column: x => x.AvaliacaoId,
                        principalTable: "Avaliacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LivroAvaliacoes_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Perfis",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDeCriacao",
                value: new DateTime(2022, 12, 30, 16, 47, 43, 388, DateTimeKind.Local).AddTicks(5458));

            migrationBuilder.UpdateData(
                table: "Perfis",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataDeCriacao",
                value: new DateTime(2022, 12, 30, 16, 47, 43, 388, DateTimeKind.Local).AddTicks(5520));

            migrationBuilder.CreateIndex(
                name: "IX_LivroAvaliacoes_LivroId",
                table: "LivroAvaliacoes",
                column: "LivroId");
        }
    }
}
