using Microsoft.EntityFrameworkCore.Migrations;

namespace ORTCine.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    edad = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    peliculaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entradaDisponibles = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(nullable: true),
                    genero = table.Column<string>(nullable: true),
                    estaDoblada = table.Column<bool>(nullable: false),
                    esAtp = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.peliculaID);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    salaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroSala = table.Column<int>(nullable: false),
                    capacidadMax = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.salaID);
                });

            migrationBuilder.CreateTable(
                name: "Entrada",
                columns: table => new
                {
                    entradaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<double>(nullable: false),
                    numeroButaca = table.Column<int>(nullable: false),
                    SalaId = table.Column<int>(nullable: true),
                    PeliculaId = table.Column<int>(nullable: true),
                    ClienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada", x => x.entradaID);
                    table.ForeignKey(
                        name: "FK_Entrada_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entrada_Pelicula_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Pelicula",
                        principalColumn: "peliculaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entrada_Sala_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Sala",
                        principalColumn: "salaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_ClienteId",
                table: "Entrada",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_PeliculaId",
                table: "Entrada",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_SalaId",
                table: "Entrada",
                column: "SalaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrada");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropTable(
                name: "Sala");
        }
    }
}
