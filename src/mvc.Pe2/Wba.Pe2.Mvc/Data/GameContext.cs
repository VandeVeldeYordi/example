using Microsoft.EntityFrameworkCore;
using Wba.Pe2.Domain;

namespace Wba.Pe2.Mvc.Data
{
    public class GameContext :DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Property> Properties { get; set; }

        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Seeder.SeedData(modelBuilder);
        }
    }
}
