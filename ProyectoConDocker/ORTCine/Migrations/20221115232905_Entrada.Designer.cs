// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ORTCine.Context;

namespace ORTCine.Migrations
{
    [DbContext(typeof(ORTCineDBContext))]
    [Migration("20221115232905_Entrada")]
    partial class Entrada
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ORTCine.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ORTCine.Models.Entrada", b =>
                {
                    b.Property<int>("entradaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("PeliculaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("numeroButaca")
                        .HasColumnType("int");

                    b.Property<int?>("salaId")
                        .HasColumnType("int");

                    b.HasKey("entradaID");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PeliculaId");

                    b.HasIndex("salaId");

                    b.ToTable("Entrada");
                });

            modelBuilder.Entity("ORTCine.Models.Pelicula", b =>
                {
                    b.Property<int>("peliculaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("esAtp")
                        .HasColumnType("bit");

                    b.Property<bool>("estaDoblada")
                        .HasColumnType("bit");

                    b.Property<int>("genero")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("salaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("peliculaID");

                    b.HasIndex("salaId");

                    b.ToTable("Pelicula");
                });

            modelBuilder.Entity("ORTCine.Models.Sala", b =>
                {
                    b.Property<int>("salaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("capacidadMax")
                        .HasColumnType("int");

                    b.Property<int>("numeroSala")
                        .HasColumnType("int");

                    b.HasKey("salaID");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("ORTCine.Models.Entrada", b =>
                {
                    b.HasOne("ORTCine.Models.Cliente", "cliente")
                        .WithMany("BoletosComprados")
                        .HasForeignKey("ClienteId");

                    b.HasOne("ORTCine.Models.Pelicula", "pelicula")
                        .WithMany("BoletosVendidos")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ORTCine.Models.Sala", "sala")
                        .WithMany("BoletosVendidos")
                        .HasForeignKey("salaId");
                });

            modelBuilder.Entity("ORTCine.Models.Pelicula", b =>
                {
                    b.HasOne("ORTCine.Models.Sala", "sala")
                        .WithMany()
                        .HasForeignKey("salaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
