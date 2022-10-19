using Pri.Festivals.Core.Entities;
using Pri.Festivals.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.InterFaces.Services
{
    public interface IOrganizerService
    {
        Task<ItemResultModel<Organizer>> GetAllAsync();
        Task<ItemResultModel<Organizer>> GetByIdAsync(int id);
        Task<ItemResultModel<Organizer>> Add(string name
            /*IEnumerable<int> festivals*/);
        Task<ItemResultModel<Organizer>> UpdateAsync(int id, string name
            /*IEnumerable<int> festivals)*/);
        Task DeleteAsync(int id);
    }
}
