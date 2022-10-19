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
    public interface IArtistService
    {
        Task<ItemResultModel<Artist>> GetAllAsync();
        Task<ItemResultModel<Artist>> GetByIdAsync(int id);
        Task<bool> Add(string name, int genreId, IFormFile image,
            IEnumerable<int> festivals);
        Task<bool> UpdateAsync(int id, string name, int genreId, IFormFile image,
            IEnumerable<int> festivals);
        Task DeleteAsync(int id);
        Task<ItemResultModel<Artist>> GetByGenreyIdAsync(int id);
    }
}
