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
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
 

        public async Task<ItemResultModel<Ticket>> Add(string name, decimal price, int available, int ticketsSold, int festivalId)
        {
            //new  ticket
            var newTicket = new Ticket
            {
                Name = name,
                Price = price,
                Available = available,
                TicketsSold = ticketsSold,
                FestivalId = festivalId
            };
            //save to the database
            if (!await _ticketRepository.AddAsync(newTicket))
            {
                return new ItemResultModel<Ticket>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult> { new ValidationResult("Something went wrong!") }
                };
            }
            //save success!
            return new ItemResultModel<Ticket> { IsSuccess = true };
        }

        public async Task DeleteAsync(int id)
        {
            //check id 
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket != null)
            {
                //delete ticket
                await _ticketRepository.DeleteAsync(ticket);
            }
        }

        public async Task<ItemResultModel<Ticket>> GetAllAsync()
        {
            var tickets = await _ticketRepository.GetAllAsync();
            ItemResultModel<Ticket> itemResultModel = new ItemResultModel<Ticket>();
            if (tickets != null)
            {
                itemResultModel.Items = tickets;
                itemResultModel.IsSuccess = true;
                return itemResultModel;
            }
            itemResultModel.ValidationErrors = new List<ValidationResult> {
                new ValidationResult("No locations found!")
            };
            return itemResultModel;
        }

        public async Task<ItemResultModel<Ticket>> GetByIdAsync(int id)
        {
            ItemResultModel<Ticket> itemResultModel = new ItemResultModel<Ticket>();
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket == null)
            {
                itemResultModel.ValidationErrors = new List<ValidationResult>
                {
                    new ValidationResult("No location found!")
                };
                return itemResultModel;
            }
            itemResultModel.Items = new List<Ticket> { ticket };
            itemResultModel.IsSuccess = true;
            return itemResultModel;
        }

        public async Task<ItemResultModel<Ticket>> UpdateAsync(int id, string name, decimal price, int available, int ticketsSold, int festivalId)
        {
            //check for null
            //get the ticket
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket == null)
            {
                return new ItemResultModel<Ticket>
                {
                    IsSuccess = false,
                    ValidationErrors =
                    new List<ValidationResult> {
                    new ValidationResult("Location not found!")
                    }
                };
            }
            //update the ticket         
            ticket.Name = name;
            ticket.Price = price;
            ticket.Available = available;
            ticket.TicketsSold = ticketsSold;
            ticket.FestivalId = festivalId;                
            //save to the db
            if (!await _ticketRepository.UpdateAsync(ticket))
            {
                return new ItemResultModel<Ticket>
                {
                    IsSuccess = false,
                    ValidationErrors = new List<ValidationResult>
                    { new ValidationResult("Something went wrong!")}
                };
            }
            //A ok
            return new ItemResultModel<Ticket> { IsSuccess = true };
        }
    }
}
