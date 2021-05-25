using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoothackForum.Data
{
    public interface IUpload
    {
        public Task DeleteImage(string userId);
        public Task UploadImage(string userId, IFormFile file);
    }
}
