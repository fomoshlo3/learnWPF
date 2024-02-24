using LAP.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAP.Data
{
    public class LAPDbContext : DbContext
    {
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<CinemaHall> CinemaHall { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Screening> Screenings { get; set; }

        public LAPDbContext(DbContextOptions<LAPDbContext> options): base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
        }
    }
}
