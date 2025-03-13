

using Microsoft.EntityFrameworkCore;
using TripulacionGoingMerry.Models;

namespace WebApplication_GoingMerry.DAL
    {


        public class TripContext : DbContext
        {
            public TripContext(DbContextOptions<TripContext> options) : base(options)
            {
            }

            public DbSet<Tripulant> Tripulants { get; set; }
            public DbSet<Enrollment> Enrollments { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Opcional: Si quieres evitar nombres en plural en la base de datos
                modelBuilder.Entity<Tripulant>().ToTable("Tripulant");
                modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            }
        }

    }
