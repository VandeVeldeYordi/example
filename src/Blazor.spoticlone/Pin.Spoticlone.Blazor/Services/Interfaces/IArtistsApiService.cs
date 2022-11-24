using Pin.Spoticlone.Blazor.Models;

namespace Pin.Spoticlone.Blazor.Services.Interfaces
{
    public interface IArtistsApiService
    {
        Task<Artist> Get(Guid id);
        Task<IQueryable<Artist>> GetAll();
    }
}