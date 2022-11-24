using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Pin.Spoticlone.Core.Entities;

namespace Pin.Spoticlone.Core.Interfaces.Services
{
    public interface IImageService
    {
        Task<Uri> AddOrUpdateImageAsync<T>(Guid id, IFormFile image) where T : EntityBase;
    }
}
