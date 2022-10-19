using Microsoft.AspNetCore.Http;
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
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IFestivalRepository _festivalRepository;
        private readonly IImageService _imageService;
        public ArtistService(IArtistRepository artistRepository , IImageService imageService , IFestivalRepository festivalRepository )
        {
            _artistRepository = artistRepository;
            _imageService = imageService;
            _festivalRepository = festivalRepository;
        }

        public async Task<bool> Add(string name, int genreId, IFormFile image, IEnumerable<int> festivals)
        {
            //get festivals
            var allFestivals = await _festivalRepository.GetAllAsync();

            var newArtist = new Artist
            {
                Name = name,
                GenreId = genreId,
                //call the imageService addAsync
                Image = await _imageService.AddImageAsync<Artist>(image),
                Festivals = allFestivals.Where(fe => festivals.Contains(fe.Id)).ToList()
            };
            try
            {
                await _artistRepository.AddAsync(newArtist);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task DeleteAsync(int id)
        {
            //check id 
            var artist = await _artistRepository.GetByIdAsync(id);
            if (artist != null)
            {
                //delete artist
                await _artistRepository.DeleteAsync(artist);
            }
        }

        public async Task<ItemResultModel<Artist>> GetAllAsync()
        {
            var artists = await _artistRepository.GetAllAsync();
            ItemResultModel<Artist> itemResultModel = new ItemResultModel<Artist>();
            if (artists != null)
            {
                itemResultModel.Items = artists;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }
            itemResultModel.ValidationErrors = new List<ValidationResult> {
                new ValidationResult("No locations found!")
            };
            return itemResultModel;
        }

        public async Task<ItemResultModel<Artist>> GetByGenreyIdAsync(int id)
        {
            var artists = await _artistRepository.GetByGenreIdAsync(id);
            if (artists == null)
            {
                return new ItemResultModel<Artist>
                {
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("no festivals found!") }
                };
            }
            return new ItemResultModel<Artist>
            {
                IsSuccess = true,
                Items = artists
            };
        }

        public async Task<ItemResultModel<Artist>> GetByIdAsync(int id)
        {
            ItemResultModel<Artist> itemResultModel = new ItemResultModel<Artist>();
            var artist = await _artistRepository.GetByIdAsync(id);
            if (artist == null)
            {
                itemResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("No artist found!")
                };
                return itemResultModel;
            }
            artist.Image = await _imageService.GetUrl<Artist>(artist.Image);
            itemResultModel.Items = new List<Artist> { artist };
            itemResultModel.IsSuccess = true;
            return itemResultModel;
        }

        public async Task<bool> UpdateAsync(int id, string name, int genreId, IFormFile image, IEnumerable<int> festivals)
        {
            var artistToUpdate = await _artistRepository.GetByIdAsync(id);
            if (artistToUpdate == null)
            {
                return false;
            }
            var allFestivals = await _festivalRepository.GetAllAsync();
            artistToUpdate.Name = name;
            artistToUpdate.GenreId = genreId;          
            artistToUpdate.Festivals = _festivalRepository.GetAll().Where(fe => festivals.Contains(fe.Id)).ToList();
            //update file on disk
            artistToUpdate.Image = await _imageService.UpdateImageAsync<Artist>(image, artistToUpdate.Image);
            try
            {
                await _artistRepository.UpdateAsync(artistToUpdate);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
