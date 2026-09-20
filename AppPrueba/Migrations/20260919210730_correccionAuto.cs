using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppPrueba.Migrations
{
    /// <inheritdoc />
    public partial class correccionAuto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Autos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Autos",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Autos");
        }
    }
}
