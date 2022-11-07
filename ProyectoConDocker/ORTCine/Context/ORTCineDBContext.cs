using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoCine;

namespace ORTCine.Context
{
    public partial class ORTCineDBContext : DbContext
    {
        public ORTCineDBContext()
        {
        }

        public ORTCineDBContext(DbContextOptions<ORTCineDBContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Entrada> entradas { get; set; }
        public DbSet<Pelicula> peliculas { get; set; }
        public DbSet<>

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=ORTCineDB;User Id=Sa;Password=Sadmsatg2022;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
