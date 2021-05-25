using BoothackForum.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BoothackForum.Service
{
    public class UploadService : IUpload
    {
        private readonly ApplicationDbContext _context;
        private IHostEnvironment _hostEnvironment;

        public UploadService(ApplicationDbContext context, IHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task UploadImage(string userId, IFormFile file)
        {
            var user = _context.ApplicationUsers.Where(u => u.Id == userId).FirstOrDefault();

            if (file != null)
            {

                var uniqueFileName = file.FileName;

                var folderPath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot\\images", "users");
                var filePath = Path.Combine(folderPath, uniqueFileName);

                file.CopyTo(new FileStream(filePath, FileMode.Create));

                user.Photo = "/images/users/" + uniqueFileName;

                await _context.SaveChangesAsync();
            }
           

        }

        public async Task DeleteImage(string userId)
        {
            var user = _context.ApplicationUsers.Where(p => p.Id == userId).FirstOrDefault();
            var fileName = user.Photo;
            var userImagePath = Path.Combine(_hostEnvironment.ContentRootPath, fileName);

            if ((System.IO.File.Exists(userImagePath)))
            {
                System.IO.File.Delete(userImagePath);
            }

            user.Photo = "/images/users/default.jpg";

            await _context.SaveChangesAsync();

        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

    }
}
