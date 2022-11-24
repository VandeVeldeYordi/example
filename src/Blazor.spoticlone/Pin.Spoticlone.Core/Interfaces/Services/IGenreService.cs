using Pin.Spoticlone.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Core.Interfaces.Services
{
    public interface IGenreService
    {

        Task<IEnumerable<GenreResponseDto>> ListAllAsync();
        Task<GenreResponseDto> GetByIdAsync(Guid id);
        Task<GenreResponseDto> AddAsync(GenreRequestDto genreRequest);
        Task<GenreResponseDto> UpdateAsync(GenreRequestDto genreRequest);
        Task DeleteAsync(Guid id);
    }
}
