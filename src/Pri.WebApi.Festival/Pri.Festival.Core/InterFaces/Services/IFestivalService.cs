using Microsoft.AspNetCore.Http;
using Pri.Festivals.Core.Entities;
using Pri.Festivals.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.InterFaces.Services
{
    public interface IFestivalService
    {
        Task<ItemResultModel<Festival>> GetAllAsync();
        Task<ItemResultModel<Festival>> GetByIdAsync(int id);
        Task<bool> Add(string name,string description, DateTime startDate, DateTime endDate, int locationId , int organizerId, IFormFile image,
            IEnumerable<int> tickets, IEnumerable<int> artists);
        Task<bool> UpdateAsync(int id, string name, string description, DateTime startDate, DateTime endDate, int locationId, int organizerId, IFormFile image,
            IEnumerable<int> tickets, IEnumerable<int> artists);
        Task DeleteAsync(int id);
        Task<ItemResultModel<Festival>> GetByOrganizerIdAsync(int id);
    }
}
