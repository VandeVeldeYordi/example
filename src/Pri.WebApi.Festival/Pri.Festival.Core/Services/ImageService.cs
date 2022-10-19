using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Pri.Festivals.Core.InterFaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ImageService(IHostEnvironment hostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _hostEnvironment = hostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> AddImageAsync<T>(IFormFile image)
        {
            //generate unique filename
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
            //generate path on disk (D:/....wwwroot/images/<entity>)
            var pathOnDisk = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot",
                "images", typeof(T).Name.ToLower());
            //check if directory exists
            if (!Directory.Exists(pathOnDisk))
            {
                Directory.CreateDirectory(pathOnDisk);
            }
            //store file
            var completePathWithFilename = Path.Combine(pathOnDisk, fileName);
            using (FileStream fileStream = new(completePathWithFilename, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            //return filename
            return fileName;
        }
        public async Task<string> GetUrl<T>(string filename)
        {
            //return the url of the image
            //https://localhost:5001/images/album/hardwired.jpg
            //get the scheme https
            var scheme = _httpContextAccessor.HttpContext.Request.Scheme;
            //get the host.Value localhost:5001
            var host = _httpContextAccessor.HttpContext.Request.Host.Value;
            //images/entityname
            var imagesFolder = $"Images/{typeof(T).Name.ToLower()}";
            //combine it together
            //var fullUrl = $"{scheme}://{host}/{filename}";
            var fullUrl = $"{scheme}://{host}/{imagesFolder}/{filename}";
            //return url
            return fullUrl;
        }
        public async Task<string> UpdateImageAsync<T>(IFormFile image, string filename)
        {
            //generate path on disk (D:/....wwwroot/images/<entity>)
            var pathOnDisk = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot",
                "images", typeof(T).Name.ToLower());
            //check if directory exists
            if (!Directory.Exists(pathOnDisk))
            {
                Directory.CreateDirectory(pathOnDisk);
            }
            //store file
            var completePathWithFilename = Path.Combine(pathOnDisk, filename);
            using (FileStream fileStream = new(completePathWithFilename, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            //return filename
            return filename;
        }
    }
}
