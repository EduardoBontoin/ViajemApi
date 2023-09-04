using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiViajem.Migrations
{
    /// <inheritdoc />
    public partial class AtualizadoDestino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Destinos");

            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "Destinos",
                newName: "Foto2");

            migrationBuilder.AddColumn<string>(
                name: "Descritivo",
                table: "Destinos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto1",
                table: "Destinos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "Destinos",
                type: "nvarchar(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descritivo",
                table: "Destinos");

            migrationBuilder.DropColumn(
                name: "Foto1",
                table: "Destinos");

            migrationBuilder.DropColumn(
                name: "Meta",
                table: "Destinos");

            migrationBuilder.RenameColumn(
                name: "Foto2",
                table: "Destinos",
                newName: "Foto");

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "Destinos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
