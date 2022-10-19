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
    public class FestivalService : IFestivalService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IFestivalRepository _festivalRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IImageService _imageService;
        public FestivalService(IArtistRepository artistRepository, IImageService imageService, IFestivalRepository festivalRepository , ITicketRepository ticketRepository)
        {
            _artistRepository = artistRepository;
            _imageService = imageService;
            _festivalRepository = festivalRepository;
            _ticketRepository = ticketRepository;   
        }

        public async Task<bool> Add(string name, string description, DateTime startDate,
            DateTime endDate, int locationId, int organizerId, IFormFile image, IEnumerable<int> tickets, IEnumerable<int> artists)
        {
            //get artists ,tickets
            var allArtists = await _artistRepository.GetAllAsync();
            var allTickets = await _ticketRepository.GetAllAsync();

            var newFestival = new Festival
            {
                Name = name,
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                LocationId = locationId,
                OrganizerId = organizerId,             
                //call the imageService addAsync
                Image = await _imageService.AddImageAsync<Festival>(image),
                Artists= allArtists.Where(fe => artists.Contains(fe.Id)).ToList(),
                Tickets = allTickets.Where(ti => tickets.Contains(ti.Id)).ToList(),
            };
            try
            {
                await _festivalRepository.AddAsync(newFestival);
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
            var festival = await _festivalRepository.GetByIdAsync(id);
            if (festival != null)
            {
                //delete festival
                await _festivalRepository.DeleteAsync(festival);
            }
        }

        public async Task<ItemResultModel<Festival>> GetAllAsync()
        {
            var festivals = await _festivalRepository.GetAllAsync();
            ItemResultModel<Festival> itemResultModel = new ItemResultModel<Festival>();
            if (festivals != null)
            {
                itemResultModel.Items = festivals;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }
            itemResultModel.ValidationErrors = new List<ValidationResult> {
                new ValidationResult("No locations found!")
            };
            return itemResultModel;
        }

        public async Task<ItemResultModel<Festival>> GetByIdAsync(int id)
        {
            ItemResultModel<Festival> itemResultModel = new ItemResultModel<Festival>();
            var festival = await _festivalRepository.GetByIdAsync(id);
            if (festival == null)
            {
                itemResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("No artist found!")
                };
                return itemResultModel;
            }
            festival.Image = await _imageService.GetUrl<Festival>(festival.Image);
            itemResultModel.Items = new List<Festival> { festival };
            itemResultModel.IsSuccess = true;
            return itemResultModel;
        }

        public async Task<ItemResultModel<Festival>> GetByOrganizerIdAsync(int id)
        {
            var festivals = await _festivalRepository.GetByOrganizerIdAsync(id);
            if(festivals == null)
            {
                return new ItemResultModel<Festival>
                {
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("No festivals found!") }
                };
            }
            return new ItemResultModel<Festival>
            {
                IsSuccess = true,
                Items = festivals
            };
        }

        public async Task<bool> UpdateAsync(int id, string name, string description, DateTime startDate, DateTime endDate, 
            int locationId, int organizerId, IFormFile image, IEnumerable<int> tickets, IEnumerable<int> artists)
        {
            var festivalToUpdate = await _festivalRepository.GetByIdAsync(id);
            if (festivalToUpdate == null)
            {
                return false;
            }
            var allTickets = await _ticketRepository.GetAllAsync();
            var allArtists = await _artistRepository.GetAllAsync();
            festivalToUpdate.Name = name;
            festivalToUpdate.Description = description;
            festivalToUpdate.StartDate = startDate;
            festivalToUpdate.EndDate = endDate;
            festivalToUpdate.LocationId = locationId;
            festivalToUpdate.OrganizerId = organizerId;
            festivalToUpdate.Tickets = _ticketRepository.GetAll().Where(ti => tickets.Contains(ti.Id)).ToList();
            festivalToUpdate.Artists = _artistRepository.GetAll().Where(ar => artists.Contains(ar.Id)).ToList();
            //update file on disk
            festivalToUpdate.Image = await _imageService.UpdateImageAsync<Artist>(image, festivalToUpdate.Image);
            try
            {
                await _festivalRepository.UpdateAsync(festivalToUpdate);
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
