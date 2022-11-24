using Pin.Spoticlone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Core.Interfaces.Repositories
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<IEnumerable<Album>> GetAlbumsFromArtistAsync(Guid artistId);
        Task<Album> GetLatestAlbum();
        Task<IEnumerable<Album>> GetTopDurationsAsync(int totalItems);
    }
}
