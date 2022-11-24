using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Pin.Spoticlone.Core.Entities;
using Pin.Spoticlone.Core.Dtos;

namespace Pin.Spoticlone.Core.Interfaces.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistResponseDto>> ListAllAsync();
        Task<ArtistResponseDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ArtistResponseDto>> GetByGenreIdAsync(Guid id);
        Task<ArtistResponseDto> AddAsync(ArtistRequestDto artistRequestDto);
        Task<ArtistResponseDto> UpdateAsync(ArtistRequestDto artistRequestDto);
        Task DeleteAsync(Guid id);
        Task<ArtistResponseDto> AddOrUpdateImageAsync(Guid id, IFormFile image);
    }
}
