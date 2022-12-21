using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookstore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTipoFornecedorMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoFornecedor",
                table: "Fornecedores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoFornecedor",
                table: "Fornecedores");
        }
    }
}
