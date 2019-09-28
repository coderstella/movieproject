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
        public FileUploadService()
        {

        }

        public string UploadFile(IFormFile posterImage, string folder)
        {
            try
            {
                var fileName = Path.GetFileName(posterImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\" + folder, fileName);

                var count = 1;
                var parts = fileName.Split(".");
                while(System.IO.File.Exists(filePath))
                {
                    var tempFileName = parts[0] + "-" + count + "." + parts[1];
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\" + folder, tempFileName);
                    count++;
                }

                using (var fileSteam = new FileStream(filePath, FileMode.CreateNew))
                {
                    posterImage.CopyTo(fileSteam);
                    return fileName;
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
