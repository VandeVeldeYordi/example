using AutoMapper;
using Pin.Spoticlone.Core.Dtos;
using Pin.Spoticlone.Core.Extensions;
using Pin.Spoticlone.Core.Interfaces.Repositories;
using Pin.Spoticlone.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Core.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly ITrackRepository _trackRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;
        public StatisticsService(IArtistRepository artistRepository,
            ITrackRepository trackRepository,
            IAlbumRepository albumRepository,
            IMapper mapper)
        {
            _artistRepository = artistRepository;
            _trackRepository = trackRepository;
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        public async Task<StatisticsResponseDto> GetStatisticsAsync(int totalItems)
        {
            var dto = new StatisticsResponseDto
            {
                TopFollowers = _mapper.Map<ICollection<ArtistResponseDto>>(await _artistRepository.GetTopFollowersAsync(totalItems)),
                TopPopularities = _mapper.Map<ICollection<ArtistResponseDto>>(await _artistRepository.GetTopPopularityAsync(totalItems)),
                TopArtistWithMostAlbums = _mapper.Map<ICollection<ArtistResponseDto>>(await _artistRepository.GetTopArtistWithMostAlbumsAsync(totalItems)),
                TopTrackDurations = _mapper.Map<ICollection<TrackResponseDto>>(await _trackRepository.GetTopDurationsAsync(totalItems)),
                TopAlbumDurations = _mapper.Map<ICollection<AlbumResponseDto>>(await _albumRepository.GetTopDurationsAsync(totalItems)),
                TotalListeningTime = _trackRepository.GetTotalTrackDurationsAsync().Result.ConvertToStringDuration()
            };

            return dto;
        }
    }
}
