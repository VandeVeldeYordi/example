using Pin.Spoticlone.Core.Dtos;
using Pin.Spoticlone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Core.Interfaces.Repositories
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetByGenreIdAsync(Guid id);
        Task<IEnumerable<Artist>> GetTopFollowersAsync(int totalItems);
        Task<IEnumerable<Artist>> GetTopPopularityAsync(int totalItems);
        Task<IEnumerable<Artist>> GetTopArtistWithMostAlbumsAsync(int totalItems);
    }
}
