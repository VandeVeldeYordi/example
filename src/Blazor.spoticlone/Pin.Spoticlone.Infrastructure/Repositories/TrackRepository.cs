using Microsoft.EntityFrameworkCore;
using Pin.Spoticlone.Infrastructure.Data;
using Pin.Spoticlone.Core.Entities;
using Pin.Spoticlone.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Infrastructure.Repositories
{
    public class TrackRepository : EfRepository<Track>, ITrackRepository
    {
        public TrackRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Track> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(a => a.Id.Equals(id));
        }

        public override IQueryable<Track> GetAllAsync()
        {
            return _dbContext.Tracks.AsNoTracking()
                .Include(a => a.Album);
        }

        public async Task<IEnumerable<Track>> SearchByNameAsync(string name)
        {
            return await GetAllAsync()
                .Where(t => t.Name.ToUpper().Contains(name.ToUpper()))
                .ToListAsync();
        }

        public async Task<IEnumerable<Track>> GetTopDurationsAsync(int totalItems)
        {
            return await GetAllAsync()
                .OrderByDescending(t => t.DurationMs)
                .Take(totalItems)
                .ToListAsync();
        }

        public async Task<long> GetTotalTrackDurationsAsync()
        {
            return await GetAllAsync().SumAsync(t => t.DurationMs);
        }
    }
}
