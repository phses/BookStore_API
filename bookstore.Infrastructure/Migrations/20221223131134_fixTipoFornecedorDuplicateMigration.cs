using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookstore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixTipoFornecedorDuplicateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Fornecedores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Fornecedores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
