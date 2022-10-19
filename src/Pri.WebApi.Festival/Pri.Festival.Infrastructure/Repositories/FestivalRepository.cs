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
    public class FestivalRepository : BaseRepository<Festival>, IFestivalRepository
    {
        public FestivalRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<IEnumerable<Festival>> GetAllAsync()
        {
            return await _table
                .Include(f => f.Location)
                .Include(f => f.Tickets)
                .Include(f => f.Organizer)
                .Include(f => f.Artists)
                .ToListAsync();
        }

        public override async Task<Festival> GetByIdAsync(int id)
        {
            return await _table
                .Include(f => f.Location)
                .Include(f => f.Tickets)
                .Include(f => f.Organizer)
                .Include(f => f.Artists)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Festival>> GetByOrganizerIdAsync(int id)
        {
            return await _table
                .Include(f => f.Location)
                .Include(f => f.Tickets)
                .Include(f => f.Organizer)
                .Include(f => f.Artists)
                .Where(f => f.OrganizerId == id).ToListAsync();
        }

        public async Task<IEnumerable<Festival>> SearchAsync(string search)
        {
            return await _table
                  .Include(f => f.Location)
                  .Include(f => f.Tickets)
                  .Include(f => f.Organizer)
                  .Include(f => f.Artists)
                  .Where(f => f.Name.ToUpper().Contains(search.ToUpper())).ToListAsync();
        }
    }
}
