using Pin.Spoticlone.Infrastructure.Data;
using Pin.Spoticlone.Core.Entities;
using Pin.Spoticlone.Core.Interfaces.Repositories;

namespace Pin.Spoticlone.Infrastructure.Repositories
{
    public class GenreRepository : EfRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
