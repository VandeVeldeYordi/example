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
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IFestivalRepository _festivalRepository;
        public LocationService(ILocationRepository locationRepository , IFestivalRepository fesivalRepository )
        {
            _locationRepository = locationRepository;
            _festivalRepository = fesivalRepository;
        }

        public async Task<ItemResultModel<Location>> Add(string name, string postal, string city/*, IEnumerable<int> festivals*/)
        {

            //get the festivals
            var allFestivals = await _festivalRepository.GetAllAsync();

            //new location
            var newLocation = new Location
            {
                Name = name,
                Postal = postal,
                City = city,
                //Festivals = allFestivals.Where(fe => festivals.Contains(fe.Id))
                //.ToList()
            };
            //save to the database
            if (!await _locationRepository.AddAsync(newLocation))
            {
                return new ItemResultModel<Location>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("Something went wrong!") }
                };
            }
            //save success!
            return new ItemResultModel<Location> { IsSuccess = true };
        }

        public async Task DeleteAsync(int id)
        {
            //check id 
            var location = await _locationRepository.GetByIdAsync(id);
            if (location != null)
            {
                //delete location
                await _locationRepository.DeleteAsync(location);
            }
        }

        public async Task<ItemResultModel<Location>> GetAllAsync()
        {
            var locations = await _locationRepository.GetAllAsync();
            ItemResultModel<Location> itemResultModel = new ItemResultModel<Location>();
            if (locations != null)
            {
                itemResultModel.Items = locations;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }
            itemResultModel.ValidationErrors = new List<ValidationResult> {
                new ValidationResult("No locations found!")
            };
            return itemResultModel;
        }

        public async Task<ItemResultModel<Location>> GetByIdAsync(int id)
        {
            ItemResultModel<Location> itemResultModel = new ItemResultModel<Location>();
            var location = await _locationRepository.GetByIdAsync(id);
            if (location == null)
            {
                itemResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("No location found!")
                };
                return itemResultModel;
            }
            itemResultModel.Items = new List<Location> { location };
            itemResultModel.IsSuccess = true;
            return itemResultModel;
        }

        public async Task<ItemResultModel<Location>> UpdateAsync(int id, string name, string postal, string city/*, IEnumerable<int> festivals*/)
        {
            //check for null
            //get the location
            var location = await _locationRepository.GetByIdAsync(id);
            if (location == null)
            {
                return new ItemResultModel<Location>
                {
                    IsSuccess = false,
                    ValidationErrors =
                    new List<ValidationResult> {
                    new ValidationResult("Location not found!")
                    }
                };
            }
            //update the location
            var allFestivals = await _festivalRepository.GetAllAsync();
            location.Name = name;
            location.Postal = postal;
            location.City = city;
            //location.Festivals =
            //_festivalRepository.GetAll().Where(fe => festivals.Contains(fe.Id))
            //.ToList();
            //save to the db
            if (!await _locationRepository.UpdateAsync(location))
            {
                return new ItemResultModel<Location>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>
                    { new ValidationResult("Something went wrong!")}
                };
            }
            //A ok
            return new ItemResultModel<Location> { IsSuccess = true };
        }
    }
}
