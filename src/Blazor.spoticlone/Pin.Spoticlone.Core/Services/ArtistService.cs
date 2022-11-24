using AutoMapper;
using Pin.Spoticlone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Pin.Spoticlone.Core.Dtos;
using Pin.Spoticlone.Core.Interfaces.Services;
using Pin.Spoticlone.Core.Interfaces.Repositories;

namespace Pin.Spoticlone.Core.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public ArtistService(IArtistRepository artistRepository,
            IImageService imageService,
            IMapper mapper)
        {
            _artistRepository = artistRepository;
            _imageService = imageService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArtistResponseDto>> ListAllAsync()
        {
            var result = await _artistRepository.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<ArtistResponseDto>>(result);
            return dto;
        }

        public async Task<ArtistResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _artistRepository.GetByIdAsync(id);
            var dto = _mapper.Map<ArtistResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<ArtistResponseDto>> GetByGenreIdAsync(Guid id)
        {
            var result = await _artistRepository.GetByGenreIdAsync(id);
            var dto = _mapper.Map<IEnumerable<ArtistResponseDto>>(result);
            return dto;
        }

        public async Task<ArtistResponseDto> AddAsync(ArtistRequestDto artistRequestDto)
        {
            var artistEntity = _mapper.Map<Artist>(artistRequestDto);

            if (artistEntity.Image == null)
            {
                artistEntity.Image = new Uri("https://via.placeholder.com/150/1ED760/ffffff?text=" + artistEntity.Name.Replace(" ", "+"), UriKind.Absolute);
            }

            await _artistRepository.AddAsync(artistEntity);
            return await GetByIdAsync(artistEntity.Id);
        }

        public async Task<ArtistResponseDto> UpdateAsync(ArtistRequestDto artistRequestDto)
        {
            var artistEntity = _mapper.Map<Artist>(artistRequestDto);
            await _artistRepository.UpdateAsync(artistEntity);
            return await GetByIdAsync(artistEntity.Id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _artistRepository.DeleteAsync(id);
        }

        public async Task<ArtistResponseDto> AddOrUpdateImageAsync(Guid id, IFormFile image)
        {
            var artist = await _artistRepository.GetByIdAsync(id);
            if (artist == null) return null;

            artist.Image = await _imageService.AddOrUpdateImageAsync<Artist>(id, image);
            await _artistRepository.UpdateAsync(artist);
            return await GetByIdAsync(id);
        }
    }
}