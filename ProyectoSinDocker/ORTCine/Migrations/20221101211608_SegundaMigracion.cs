using Microsoft.EntityFrameworkCore.Migrations;

namespace ORTCine.Migrations
{
    public partial class SegundaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numeroSala",
                table: "Sala");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "numeroSala",
                table: "Sala",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
