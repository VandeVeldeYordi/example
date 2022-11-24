using Microsoft.EntityFrameworkCore;
using Pin.Spoticlone.Infrastructure.Data.Seeding;
using Pin.Spoticlone.Core.Entities;

namespace Pin.Spoticlone.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<ArtistGenre> ArtistGenres { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtistGenre>()
                .ToTable("ArtistGenre")
                .HasKey(ag => new { ag.ArtistId, ag.GenreId });
            modelBuilder.Entity<ArtistGenre>()
                .HasOne(ag => ag.Artist)
                .WithMany(g => g.ArtistGenres)
                .HasForeignKey(ag => ag.ArtistId);
            modelBuilder.Entity<ArtistGenre>()
                .HasOne(ag => ag.Genre)
                .WithMany(a => a.ArtistGenres)
                .HasForeignKey(ag => ag.GenreId);

            ArtistSeeder.Seed(modelBuilder);
            GenreSeeder.Seed(modelBuilder);
            AlbumSeeder.Seed(modelBuilder);
            TrackSeeder.Seed(modelBuilder);
            ArtistGenreSeeder.Seed(modelBuilder);
        }
    }
}
