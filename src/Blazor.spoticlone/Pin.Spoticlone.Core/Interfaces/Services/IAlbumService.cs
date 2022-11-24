using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Pin.Spoticlone.Core.Dtos;

namespace Pin.Spoticlone.Core.Interfaces.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumResponseDto>> ListAllAsync();
        Task<AlbumResponseDto> GetByIdAsync(Guid id);
        Task<AlbumResponseDto> AddAsync(AlbumRequestDto albumRequest);
        Task<AlbumResponseDto> UpdateAsync(AlbumRequestDto albumRequest);
        Task DeleteAsync(Guid id);
        Task<AlbumResponseDto> AddOrUpdateImageAsync(Guid id, IFormFile image);

        Task<AlbumResponseDto> GetLatestAlbum();
        Task<IEnumerable<AlbumResponseDto>> GetAlbumsFromArtistAsync(Guid artistId);
    }
}
