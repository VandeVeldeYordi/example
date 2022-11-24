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
    public class GenreService : IGenreService
    {

        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository,
            IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreResponseDto>> ListAllAsync()
        {
            var result = await _genreRepository.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<GenreResponseDto>>(result);
            return dto;
        }

        public async Task<GenreResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _genreRepository.GetByIdAsync(id);
            var dto = _mapper.Map<GenreResponseDto>(result);
            return dto;
        }

        public async Task<GenreResponseDto> AddAsync(GenreRequestDto genreRequest)
        {
            var entity = _mapper.Map<Genre>(genreRequest);
            await _genreRepository.AddAsync(entity);
            return await GetByIdAsync(entity.Id);
        }

        public async Task<GenreResponseDto> UpdateAsync(GenreRequestDto genreRequest)
        {
            var entity = _mapper.Map<Genre>(genreRequest);
            await _genreRepository.UpdateAsync(entity);
            return await GetByIdAsync(entity.Id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _genreRepository.DeleteAsync(id);
        }
    }
}
