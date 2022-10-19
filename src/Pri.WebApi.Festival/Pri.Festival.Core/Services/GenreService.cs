using Pri.Festivals.Core.Entities;
using Pri.Festivals.Core.InterFaces.Repositories;
using Pri.Festivals.Core.InterFaces.Services;
using Pri.Festivals.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IArtistRepository _artistRepository;
        public GenreService(IGenreRepository genreRepository , IArtistRepository artistRepository)
        {
            _genreRepository = genreRepository;
            _artistRepository = artistRepository;
        }

        public async Task<ItemResultModel<Genre>> Add(string name, string description/*, IEnumerable<int> artists*/)
        {
            //get the artists
            var allArtists = await _artistRepository.GetAllAsync();

            //new genre
            var newGenre = new Genre
            {
                Name = name,
                Description= description              
                //Artists= allArtists.Where(ar => artists.Contains(ar.Id))
                //.ToList()
            };
            //save to the database
            if (!await _genreRepository.AddAsync(newGenre))
            {
                return new ItemResultModel<Genre>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("Something went wrong!") }
                };
            }
            //save success!
            return new ItemResultModel<Genre> { IsSuccess = true };
        }

        public async Task DeleteAsync(int id)
        {
            //check id 
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre != null)
            {
                //delete genre
                await _genreRepository.DeleteAsync(genre);
            }
        }

        public async Task<ItemResultModel<Genre>> GetAllAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            ItemResultModel<Genre> itemResultModel = new ItemResultModel<Genre>();
            if (genres != null)
            {
                itemResultModel.Items = genres;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }
            itemResultModel.ValidationErrors = new List<ValidationResult> {
                new ValidationResult("No genress found!")
            };
            return itemResultModel;
        }

        public async Task<ItemResultModel<Genre>> GetByIdAsync(int id)
        {
            ItemResultModel<Genre> itemResultModel = new ItemResultModel<Genre>();
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null)
            {
                itemResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("No genre found!")
                };
                return itemResultModel;
            }
            itemResultModel.Items = new List<Genre> { genre };
            itemResultModel.IsSuccess = true;
            return itemResultModel;
        }

        public async Task<ItemResultModel<Genre>> UpdateAsync(int id, string name, string description/*, IEnumerable<int> artists*/)
        {
            //check for null
            //get the genre
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null)
            {
                return new ItemResultModel<Genre>
                {
                    IsSuccess = false,
                    ValidationErrors =
                    new List<ValidationResult> {
                    new ValidationResult("Genre not found!")
                    }
                };
            }
            //update the genre
            var allArtists = await _artistRepository.GetAllAsync();
            genre.Name = name;      
            genre.Description = description;
            //genre.Artists=
            //_artistRepository.GetAll().Where(ar => artists.Contains(ar.Id))
            //.ToList();
            //save to the db
            if (!await _genreRepository.UpdateAsync(genre))
            {
                return new ItemResultModel<Genre>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>
                    { new ValidationResult("Something went wrong!")}
                };
            }
            //A ok
            return new ItemResultModel<Genre> { IsSuccess = true };
        }
    }
}
