using Microsoft.EntityFrameworkCore;
using Pri.Festivals.Core.Entities;
using Pri.Festivals.Core.InterFaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Infrastructure.Repositories
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _table
                .Include(l => l.Festivals)
                .ToListAsync();
        }

        public override async Task<Location> GetByIdAsync(int id)
        {
            return await _table
                .Include(l => l.Festivals)
                .FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
