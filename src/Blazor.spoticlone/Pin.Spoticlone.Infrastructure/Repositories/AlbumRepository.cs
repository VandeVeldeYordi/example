using Microsoft.EntityFrameworkCore;
using Pin.Spoticlone.Core.Entities;
using Pin.Spoticlone.Infrastructure.Data;
using Pin.Spoticlone.Core.Entities;
using Pin.Spoticlone.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Infrastructure.Repositories
{
    public class AlbumRepository : EfRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Album> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(a => a.Id.Equals(id));
        }

        public override IQueryable<Album> GetAllAsync()
        {
            return _dbContext.Albums.AsNoTracking()
                .Include(a => a.Tracks)
                .Include(a => a.Artist);
        }

        public async Task<Album> GetLatestAlbum()
        {
            return await GetAllAsync().OrderByDescending(a => a.ReleaseDate).LastOrDefaultAsync();
        }

        public async Task<IEnumerable<Album>> GetTopDurationsAsync(int totalItems)
        {
            return await GetAllAsync()
                .OrderByDescending(a => a.Tracks.Sum(t => t.DurationMs))
                .Take(totalItems)
                .ToListAsync();
        }

        public async Task<IEnumerable<Album>> GetAlbumsFromArtistAsync(Guid artistId)
        {
            return await GetAllAsync()
                .Where(a => a.ArtistId.Equals(artistId))
                .ToListAsync();
        }
    }
}
