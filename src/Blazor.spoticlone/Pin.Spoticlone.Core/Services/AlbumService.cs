using AutoMapper;
using Pin.Spoticlone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Pin.Spoticlone.Core.Interfaces.Services;
using Pin.Spoticlone.Core.Dtos;
using Pin.Spoticlone.Core.Interfaces.Repositories;

namespace Pin.Spoticlone.Core.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository albumRepository,
            IArtistRepository artistRepository,
            IImageService imageService,
            IMapper mapper)
        {
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
            _imageService = imageService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AlbumResponseDto>> ListAllAsync()
        {
            var result = await _albumRepository.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<AlbumResponseDto>>(result);
            return dto;
        }

        public async Task<AlbumResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _albumRepository.GetByIdAsync(id);
            var dto = _mapper.Map<AlbumResponseDto>(result);
            return dto;
        }

        public async Task<AlbumResponseDto> AddAsync(AlbumRequestDto albumRequest)
        {
            var entity = _mapper.Map<Album>(albumRequest);

            if (entity.Image == null)
            {
                entity.Image = new Uri("https://via.placeholder.com/150/1ED760/ffffff?text=" + entity.Name.Replace(" ", "+"), UriKind.Absolute);
            }
            await _albumRepository.AddAsync(entity);
            return await GetByIdAsync(entity.Id);
        }

        public async Task<AlbumResponseDto> UpdateAsync(AlbumRequestDto albumRequest)
        {
            var entity = _mapper.Map<Album>(albumRequest);
            await _albumRepository.UpdateAsync(entity);
            return await GetByIdAsync(entity.Id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _albumRepository.DeleteAsync(id);
        }

        public async Task<AlbumResponseDto> AddOrUpdateImageAsync(Guid id, IFormFile image)
        {
            var album = await _albumRepository.GetByIdAsync(id);
            if (album == null) return null;

            album.Image = await _imageService.AddOrUpdateImageAsync<Album>(id, image);
            await _albumRepository.UpdateAsync(album);

            return await GetByIdAsync(id);
        }

        public async Task<AlbumResponseDto> GetLatestAlbum()
        {
            var album = await _albumRepository.GetLatestAlbum();
            return await GetByIdAsync(album.Id); // For the includes and mapping
        }

        public async Task<IEnumerable<AlbumResponseDto>> GetAlbumsFromArtistAsync(Guid artistId)
        {
            var albums = await _albumRepository.GetAlbumsFromArtistAsync(artistId);
            return _mapper.Map<IEnumerable<AlbumResponseDto>>(albums);
        }
    }
}
