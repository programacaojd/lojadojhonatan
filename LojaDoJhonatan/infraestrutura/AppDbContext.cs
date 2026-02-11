using Microsoft.EntityFrameworkCore;
using LojaDoJhonatan.dominio;

namespace LojaDoJhonatan.infraestrutura
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options) { }

            public DbSet<Celular> Celulares { get; set; }
            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Tecnico> Tecnicos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Celular>()
                    .HasKey(c => c.IdCelular);
                modelBuilder.Entity<Cliente>()
                    .HasKey(c => c.IdCliente);
            modelBuilder.Entity<Tecnico>()
                    .HasKey(c => c.IdTecnico);
        }
        }
    }
