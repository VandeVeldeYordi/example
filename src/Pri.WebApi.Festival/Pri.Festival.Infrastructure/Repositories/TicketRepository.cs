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
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _table
                 .Include(t => t.Festival)
                 .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetByFestivalIdAsync(int id)
        {
            return await _table
               .Include(t => t.Festival)
               .Where(t => t.FestivalId == id).ToListAsync();
        }

        public override async Task<Ticket> GetByIdAsync(int id)
        {
            return await _table
               .Include(t => t.Festival)
               .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
