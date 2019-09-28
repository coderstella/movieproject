using Microsoft.AspNetCore.Http;

namespace movieproject.Services
{
    public interface IFileUploadService
    {
        string UploadFile(IFormFile posterImage, string folder);
    }
}