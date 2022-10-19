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
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public override async Task<Genre> GetByIdAsync(int id)
        {
            return await _table
                .Include(g => g.Artists)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
        public override async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _table
                .Include(g => g.Artists)
                .ToListAsync();
        }
        public async Task<IEnumerable<Genre>> SearchAsync(string search)
        {
            return await _table
                 .Include(g => g.Artists)
                 .Where(g => g.Name.ToUpper().Contains(search.ToUpper())).ToListAsync();
        }
    }
}
