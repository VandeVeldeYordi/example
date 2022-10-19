using Pri.Festivals.Core.Entities;
using Pri.Festivals.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.InterFaces.Services
{
    public interface IGenreService
    {
        Task<ItemResultModel<Genre>> GetAllAsync();
        Task<ItemResultModel<Genre>> GetByIdAsync(int id);
        Task<ItemResultModel<Genre>> Add(string name,string description
           /* IEnumerable<int> artists*/);
        Task<ItemResultModel<Genre>> UpdateAsync(int id, string name, string description
          /*  IEnumerable<int> artists*/);
        Task DeleteAsync(int id);
    }
}
