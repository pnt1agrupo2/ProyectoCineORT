using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ORTCine.Models;

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
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pelicula> Pelicula { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<Entrada> Entrada { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-MEJBB3R\\ORT2022C2;Database=ORTCineDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
