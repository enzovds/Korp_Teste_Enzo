using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaturamentoService.Migrations
{
    /// <inheritdoc />
    public partial class AjusteCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "NotasFiscais",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "NotasFiscais");
        }
    }
}
