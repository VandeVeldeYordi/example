using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pri.Festivals.Core.Entities;
using Pri.Festivals.Infrastructure.Data.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
          public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Festival> Festivals { get; set; }
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
