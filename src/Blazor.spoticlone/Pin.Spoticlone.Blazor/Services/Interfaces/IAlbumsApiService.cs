using Pin.Spoticlone.Blazor.Models;

namespace Pin.Spoticlone.Blazor.Services.Interfaces
{
    public interface IAlbumsApiService
    {
      
            Task<Album> Get(Guid id);
            Task<IQueryable<Album>> GetAll();
        
    }
}
