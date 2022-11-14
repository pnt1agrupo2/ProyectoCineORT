using Microsoft.EntityFrameworkCore.Migrations;

namespace ORTCine.Migrations
{
    public partial class modelPelicula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "entradaDisponibles",
                table: "Pelicula");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Pelicula",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "genero",
                table: "Pelicula",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "salaId",
                table: "Pelicula",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pelicula_salaId",
                table: "Pelicula",
                column: "salaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pelicula_Sala_salaId",
                table: "Pelicula",
                column: "salaId",
                principalTable: "Sala",
                principalColumn: "salaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pelicula_Sala_salaId",
                table: "Pelicula");

            migrationBuilder.DropIndex(
                name: "IX_Pelicula_salaId",
                table: "Pelicula");

            migrationBuilder.DropColumn(
                name: "salaId",
                table: "Pelicula");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Pelicula",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "genero",
                table: "Pelicula",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "entradaDisponibles",
                table: "Pelicula",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
