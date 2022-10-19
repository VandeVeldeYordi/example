using Pri.Festivals.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.InterFaces.Repositories
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetByGenreIdAsync(int id);
        Task<IEnumerable<Artist>> SearchAsync(string search);
    }
}
