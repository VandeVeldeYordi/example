using Pri.Festivals.Core.Entities;
using Pri.Festivals.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.InterFaces.Services
{
    public interface ITicketService
    {

        Task<ItemResultModel<Ticket>> GetAllAsync();
        Task<ItemResultModel<Ticket>> GetByIdAsync(int id);
        Task<ItemResultModel<Ticket>> Add(string name,
            decimal price, int available, int ticketsSold, int festivalId);
        Task<ItemResultModel<Ticket>> UpdateAsync(int id, string name,
            decimal price , int available , int ticketsSold , int festivalId);    
        Task DeleteAsync(int id);
    }
}
