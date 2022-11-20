using Microsoft.EntityFrameworkCore.Migrations;

namespace ORTCine.Migrations
{
    public partial class Entrada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Sala_salaID",
                table: "Entrada");

            migrationBuilder.RenameColumn(
                name: "salaID",
                table: "Entrada",
                newName: "salaId");

            migrationBuilder.RenameIndex(
                name: "IX_Entrada_salaID",
                table: "Entrada",
                newName: "IX_Entrada_salaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Sala_salaId",
                table: "Entrada",
                column: "salaId",
                principalTable: "Sala",
                principalColumn: "salaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Sala_salaId",
                table: "Entrada");

            migrationBuilder.RenameColumn(
                name: "salaId",
                table: "Entrada",
                newName: "salaID");

            migrationBuilder.RenameIndex(
                name: "IX_Entrada_salaId",
                table: "Entrada",
                newName: "IX_Entrada_salaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Sala_salaID",
                table: "Entrada",
                column: "salaID",
                principalTable: "Sala",
                principalColumn: "salaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
