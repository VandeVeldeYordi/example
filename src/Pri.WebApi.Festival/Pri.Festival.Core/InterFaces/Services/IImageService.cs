using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.InterFaces.Services
{
    public interface IImageService
    {
        Task<string> AddImageAsync<T>(IFormFile Image);
        Task<string> UpdateImageAsync<T>(IFormFile Image, string filename);
        Task<string> GetUrl<T>(string filename);
    }
}
