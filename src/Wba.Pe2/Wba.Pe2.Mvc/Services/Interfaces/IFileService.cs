using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Wba.Pe2.Mvc.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> StoreFile(IFormFile file, string subPath);
        Task<string> StoreFile(IFormFile file, string subPath, string existingFileName);
    }
}
