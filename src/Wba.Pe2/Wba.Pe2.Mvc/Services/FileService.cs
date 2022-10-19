using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using Wba.Pe2.Mvc.Services.Interfaces;

namespace Wba.Pe2.Mvc.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> StoreFile(IFormFile file, string subPath)
        {
            //create image path
            string fileName = $"{Guid.NewGuid()}_{file.FileName}";
            return await StoreFile(file, subPath, fileName);
        }

        public async Task<string> StoreFile(IFormFile file, string subPath, string existingFileName)
        {
            string filePath = Path
                .Combine(_webHostEnvironment.WebRootPath, "images", subPath, existingFileName);

            //store image
            using (FileStream fileStream = new(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return existingFileName;
        }
    }
}
