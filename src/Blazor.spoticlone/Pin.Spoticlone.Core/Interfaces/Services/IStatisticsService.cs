using Pin.Spoticlone.Core.Dtos;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Core.Interfaces.Services
{
    public interface IStatisticsService
    {
        Task<StatisticsResponseDto> GetStatisticsAsync(int totalItems);
    }
}
