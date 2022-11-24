using AutoMapper;
using Pin.Spoticlone.Core.Dtos;
using Pin.Spoticlone.Core.Interfaces.Repositories;
using Pin.Spoticlone.Core.Interfaces.Services;
using Pin.Spoticlone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Core.Services
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public TrackService(ITrackRepository trackRepository,
            IAlbumRepository albumRepository,
            IMapper mapper)
        {
            _trackRepository = trackRepository;
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TrackResponseDto>> ListAllAsync()
        {
            var result = await _trackRepository.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<TrackResponseDto>>(result);
            return dto;
        }

        public async Task<TrackResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _trackRepository.GetByIdAsync(id);

            var dto = _mapper.Map<TrackResponseDto>(result);
            return dto;
        }

        public async Task<TrackResponseDto> AddAsync(TrackRequestDto trackRequest)
        {
            var entity = _mapper.Map<Track>(trackRequest);
            await _trackRepository.AddAsync(entity);
            return await GetByIdAsync(entity.Id);
        }

        public async Task<TrackResponseDto> UpdateAsync(TrackRequestDto trackRequest)
        {
            var entity = _mapper.Map<Track>(trackRequest);
            await _trackRepository.UpdateAsync(entity);
            return await GetByIdAsync(entity.Id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _trackRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TrackResponseDto>> SearchByNameAsync(string name)
        {
            var tracks = await _trackRepository.SearchByNameAsync(name);
            return _mapper.Map<IEnumerable<TrackResponseDto>>(tracks);
        }

        public async Task<IEnumerable<TrackResponseDto>> GetTracksByAlbumIdAsync(Guid id)
        {
            var tracks = await _trackRepository.ListFiltered(t => t.AlbumId.Equals(id));

            return _mapper.Map<IEnumerable<TrackResponseDto>>(tracks);
        }
    }
}
