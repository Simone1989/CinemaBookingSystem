using CinemaBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaBookingSystem.Data
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Auditorium> Auditoriums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Screening>()
                .HasOne(s => s.Auditorium)
                .WithMany(a => a.Screenings);
        }
        
    }
}
