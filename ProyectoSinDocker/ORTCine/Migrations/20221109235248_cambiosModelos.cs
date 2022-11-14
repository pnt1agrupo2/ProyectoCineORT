using Microsoft.EntityFrameworkCore.Migrations;

namespace ORTCine.Migrations
{
    public partial class cambiosModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Pelicula_PeliculaId",
                table: "Entrada");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Sala_SalaId",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "valor",
                table: "Entrada");

            migrationBuilder.RenameColumn(
                name: "SalaId",
                table: "Entrada",
                newName: "salaID");

            migrationBuilder.RenameIndex(
                name: "IX_Entrada_SalaId",
                table: "Entrada",
                newName: "IX_Entrada_salaID");

            migrationBuilder.AlterColumn<int>(
                name: "PeliculaId",
                table: "Entrada",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "apellido",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Pelicula_PeliculaId",
                table: "Entrada",
                column: "PeliculaId",
                principalTable: "Pelicula",
                principalColumn: "peliculaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Sala_salaID",
                table: "Entrada",
                column: "salaID",
                principalTable: "Sala",
                principalColumn: "salaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Pelicula_PeliculaId",
                table: "Entrada");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Sala_salaID",
                table: "Entrada");

            migrationBuilder.RenameColumn(
                name: "salaID",
                table: "Entrada",
                newName: "SalaId");

            migrationBuilder.RenameIndex(
                name: "IX_Entrada_salaID",
                table: "Entrada",
                newName: "IX_Entrada_SalaId");

            migrationBuilder.AlterColumn<int>(
                name: "PeliculaId",
                table: "Entrada",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<double>(
                name: "valor",
                table: "Entrada",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "apellido",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Pelicula_PeliculaId",
                table: "Entrada",
                column: "PeliculaId",
                principalTable: "Pelicula",
                principalColumn: "peliculaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Sala_SalaId",
                table: "Entrada",
                column: "SalaId",
                principalTable: "Sala",
                principalColumn: "salaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
