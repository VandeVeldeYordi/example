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
    public class OrganizerRepository : BaseRepository<Organizer>, IOrganizerRepository
    {
        public OrganizerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<IEnumerable<Organizer>> GetAllAsync()
        {
            return await _table
                .Include(o => o.Festivals)
                .ToListAsync();
        }

        public override async Task<Organizer> GetByIdAsync(int id)
        {
            return await _table
               .Include(o => o.Festivals)
               .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
