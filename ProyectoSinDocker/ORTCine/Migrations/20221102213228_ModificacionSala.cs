using Microsoft.EntityFrameworkCore.Migrations;

namespace ORTCine.Migrations
{
    public partial class ModificacionSala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "capacidadMax",
                table: "Sala",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "numeroSala",
                table: "Sala",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "capacidadMax",
                table: "Sala");

            migrationBuilder.DropColumn(
                name: "numeroSala",
                table: "Sala");
        }
    }
}
