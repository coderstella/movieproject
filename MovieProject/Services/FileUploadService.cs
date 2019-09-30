using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public FileUploadService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string UploadFile(IFormFile posterImage, string folder)
        {            
            try
            {
                var contentRootPath = _hostingEnvironment.ContentRootPath;
                var fileName = Path.GetFileName(posterImage.FileName);
                var uploadLocation = Path.Combine(contentRootPath, "wwwroot\\assets\\" + folder);
                
                if (!Directory.Exists(uploadLocation))
                {
                    Directory.CreateDirectory(uploadLocation);
                }

                var filePath = Path.Combine(uploadLocation, fileName);
                var count = 1;
                var parts = fileName.Split(".");
                while(System.IO.File.Exists(filePath))
                {
                    var tempFileName = parts[0] + "-" + count + "." + parts[1];
                    filePath = Path.Combine(uploadLocation, tempFileName);
                    count++;
                }

                using (var fileSteam = new FileStream(filePath, FileMode.CreateNew))
                {
                    posterImage.CopyTo(fileSteam);
                    return folder + '/' + fileName;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /*
        public string UniqueFileName(IFormFile posterImage, string folder)
        {
            try
            {
                if (posterImage != null)
                {
                    var fileName = Path.GetFileName(posterImage.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\" + folder, fileName);

                    var count = 1;
                    var paths = filePath.Split(".");
                    while (System.IO.File.Exists(filePath))
                    {
                        var tempPath = paths[0] + "-" + count.ToString() + "." + paths[1];
                        filePath = tempPath;
                        count++;
                    }

                    using (var fileSteam = new FileStream(filePath, FileMode.CreateNew))
                    {
                        posterImage.CopyTo(fileSteam);
                        var poster = fileName.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        */

    }
}
