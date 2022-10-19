using Pri.Festivals.Core.Entities;
using Pri.Festivals.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.InterFaces.Services
{
    public interface ILocationService
    {
        Task<ItemResultModel<Location>> GetAllAsync();
        Task<ItemResultModel<Location>> GetByIdAsync(int id);
        Task<ItemResultModel<Location>> Add(string name, string postal,string city
            /*IEnumerable<int> festivals*/);
        Task<ItemResultModel<Location>> UpdateAsync(int id, string name, string postal, string city
            /*IEnumerable<int> festivals*/);
        Task DeleteAsync(int id);
    }
}
