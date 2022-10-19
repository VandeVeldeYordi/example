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
    public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public async Task<IEnumerable<Artist>> GetByGenreIdAsync(int id)
        {
            return await _table
               .Include(a => a.Genre)
               .Include(a => a.Festivals)
               .Where(a => a.GenreId == id).ToListAsync();
        }
        public override async Task<Artist> GetByIdAsync(int id)
        {
            return await _table
                .Include(a => a.Genre)
                .Include(a => a.Festivals)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        public override async Task<IEnumerable<Artist>> GetAllAsync()
        {
            return await _table
                 .Include(p => p.Genre)
                 .Include(p => p.Festivals)
                 .ToListAsync();
        }
        public async Task<IEnumerable<Artist>> SearchAsync(string search)
        {
            return await _table
               .Include(a => a.Genre)
               .Include(a => a.Festivals)
               .Where(a => a.Name.ToUpper().Contains(search.ToUpper())).ToListAsync();
        }
    }
}
