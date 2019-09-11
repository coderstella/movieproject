using Microsoft.AspNetCore.Http;

namespace MovieProject.Services
{
    public interface IFileUploadService
    {
        string UploadFile(IFormFile posterImage, string folder);
    }
}