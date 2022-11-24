using System.Collections.Generic;
using System.Threading.Tasks;
using Pin.Spoticlone.Core.Entities;

namespace Pin.Spoticlone.Core.Interfaces.Repositories
{
    public interface ITrackRepository : IRepository<Track>
    {
        Task<IEnumerable<Track>> SearchByNameAsync(string name);
        Task<IEnumerable<Track>> GetTopDurationsAsync(int totalItems);
        Task<long> GetTotalTrackDurationsAsync();
    }
}
