using Pin.Spoticlone.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Core.Interfaces.Services
{
    public interface ITrackService
    {
        Task<IEnumerable<TrackResponseDto>> ListAllAsync();
        Task<TrackResponseDto> GetByIdAsync(Guid id);
        Task<TrackResponseDto> AddAsync(TrackRequestDto trackRequest);
        Task<TrackResponseDto> UpdateAsync(TrackRequestDto trackRequest);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<TrackResponseDto>> SearchByNameAsync(string name);
        Task<IEnumerable<TrackResponseDto>> GetTracksByAlbumIdAsync(Guid id);
    }
}
