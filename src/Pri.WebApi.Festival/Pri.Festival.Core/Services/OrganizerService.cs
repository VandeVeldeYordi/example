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
    public class OrganizerService : IOrganizerService
    {
        private readonly IOrganizerRepository _organizerRepository;
        private readonly IFestivalRepository _festivalRepository;
        public OrganizerService(IOrganizerRepository organizerReposiotry , IFestivalRepository festivalRepository )
        {
            _organizerRepository = organizerReposiotry;
            _festivalRepository = festivalRepository;
        }

        public async Task<ItemResultModel<Organizer>> Add(string name/*, IEnumerable<int> festivals*/)
        {
            //get the Organizer
            var allFestivals = await _festivalRepository.GetAllAsync();

            //new organizer
            var newOrganizer = new Organizer
            {
                Name = name,           
                //Festivals = allFestivals.Where(fe => festivals.Contains(fe.Id))
                //.ToList()
            };
            //save to the database
            if (!await _organizerRepository.AddAsync(newOrganizer))
            {
                return new ItemResultModel<Organizer>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("Something went wrong!") }
                };
            }
            //save success!
            return new ItemResultModel<Organizer> { IsSuccess = true };
        }

        public async Task DeleteAsync(int id)
        {
            //check id 
            var organizer = await _organizerRepository.GetByIdAsync(id);
            if (organizer != null)
            {
                //delete organizer
                await _organizerRepository.DeleteAsync(organizer);
            }
        }
        public async Task<ItemResultModel<Organizer>> GetAllAsync()
        {
                var organizers = await _organizerRepository.GetAllAsync();
                ItemResultModel<Organizer> itemResultModel = new ItemResultModel<Organizer>();
                if (organizers != null)
                {
                    itemResultModel.Items = organizers;
                    itemResultModel.IsSuccess = true;
                    return itemResultModel;
                }
                itemResultModel.ValidationErrors = new List<ValidationResult> {
                new ValidationResult("No locations found!")
            };
                return itemResultModel;
            }

        public async Task<ItemResultModel<Organizer>> GetByIdAsync(int id)
        {
            ItemResultModel<Organizer> itemResultModel = new ItemResultModel<Organizer>();
            var organizer = await _organizerRepository.GetByIdAsync(id);
            if (organizer == null)
            {
                itemResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("No location found!")
                };
                return itemResultModel;
            }
            itemResultModel.Items = new List<Organizer> { organizer };
            itemResultModel.IsSuccess = true;
            return itemResultModel;
        }

        public async Task<ItemResultModel<Organizer>> UpdateAsync(int id, string name/*, IEnumerable<int> festivals*/)
        {
            //check for null
            //get the orga izer
            var organizer = await _organizerRepository.GetByIdAsync(id);
            if (organizer == null)
            {
                return new ItemResultModel<Organizer>
                {
                    IsSuccess = false,
                    ValidationErrors =
                    new List<ValidationResult> {
                    new ValidationResult("Location not found!")
                    }
                };
            }
            //update the organizer
            var allFestivals = await _festivalRepository.GetAllAsync();
            organizer.Name = name;                  
            //organizer.Festivals =
            //_festivalRepository.GetAll().Where(fe => festivals.Contains(fe.Id))
            //.ToList();
            //save to the db
            if (!await _organizerRepository.UpdateAsync(organizer))
            {
                return new ItemResultModel<Organizer>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>
                    { new ValidationResult("Something went wrong!")}
                };
            }
            //A ok
            return new ItemResultModel<Organizer> { IsSuccess = true };
        }
    }
}
