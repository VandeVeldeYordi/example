namespace Pin.Spoticlone.Blazor.Services
{
    public interface ICRUDService<T>
        where T : class
    {
        Task<IQueryable<T>> GetAll();
        Task<T> GetTrackById(Guid id);
        Task<IQueryable<T>> Get(Guid id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(Guid id);
    }
}