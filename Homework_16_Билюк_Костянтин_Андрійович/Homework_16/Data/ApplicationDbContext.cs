using Homework_16.Data.Configurations;
using Homework_16.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Homework_16.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Showtime> Showtimes { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Hall> Halls { get; set; } = null!;
        public DbSet<HallPosition> HallPositions { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Cinema> Cinemas { get; set; } = null!;

        public ApplicationDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3PNIESA\\SQLEXPRESS; Database = NetworkCinema; TrustServerCertificate=True; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new CinemaConfiguration());
            modelBuilder.ApplyConfiguration(new ShowtimeConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new HallConfiguration());
            modelBuilder.ApplyConfiguration(new HallPositionConfiguration());
        }
    }
}
