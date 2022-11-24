using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Pin.Spoticlone.Core.Interfaces.Services;
using Pin.Spoticlone.Core.Entities;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly IHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ImageService(IHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Uri> AddOrUpdateImageAsync<T>(Guid id, IFormFile image) where T : EntityBase
        {
            var newFileNameWithExtension = $"{id}{Path.GetExtension(image.FileName)}";
            var rootPath = Path.Combine(_webHostEnvironment.ContentRootPath,
                "wwwroot",
                "images",
                typeof(T).Name.ToLower());

            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
            var filePath = Path.Combine(rootPath, newFileNameWithExtension);

            if (image.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
            }

            return new Uri(
                $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/images/{typeof(T).Name.ToLower()}/{newFileNameWithExtension}",
                UriKind.Absolute);
        }
    }
}
