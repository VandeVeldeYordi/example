using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Pin.Spoticlone.Infrastructure.Data;
using Pin.Spoticlone.Core.Interfaces.Repositories;
using Pin.Spoticlone.Core.Entities;

namespace Pin.Spoticlone.Infrastructure.Repositories
{
    public class ArtistRepository : EfRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Artist> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(a => a.Id.Equals(id));
        }

        public override IQueryable<Artist> GetAllAsync()
        {
            return _dbContext.Artists.AsNoTracking()
                .Include(a => a.ArtistGenres)
                    .ThenInclude(a => a.Genre)
                .Include(a => a.Albums);
        }

        public async Task<IEnumerable<Artist>> GetByGenreIdAsync(Guid id)
        {
            return await GetAllAsync()
                .Where(a => a.ArtistGenres.Any(ag => ag.GenreId.Equals(id)))
                .ToListAsync();
        }

        public async Task<IEnumerable<Artist>> GetTopFollowersAsync(int totalItems)
        {
            return await GetAllAsync()
                .OrderByDescending(a => a.Followers)
                .Take(totalItems)
                .ToListAsync();
        }

        public async Task<IEnumerable<Artist>> GetTopPopularityAsync(int totalItems)
        {
            return await GetAllAsync()
                .OrderByDescending(a => a.Popularity)
                .Take(totalItems)
                .ToListAsync();
        }

        public async Task<IEnumerable<Artist>> GetTopArtistWithMostAlbumsAsync(int totalItems)
        {
            return await GetAllAsync()
                .OrderByDescending(a => a.Albums.Count)
                .Take(totalItems)
                .ToListAsync();
        }
    }
}
