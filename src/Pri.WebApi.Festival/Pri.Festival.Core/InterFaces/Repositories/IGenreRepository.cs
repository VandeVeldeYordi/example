using Pri.Festivals.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.InterFaces.Repositories
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<IEnumerable<Genre>> SearchAsync(string search);
    }
}
