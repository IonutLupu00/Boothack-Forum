using Microsoft.AspNetCore.Http;
using System;

namespace BoothackForum.Models.ApplicationUserModel
{
    public class ProfileModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int UserRating { get; set; }
        public string ProfileImageURL { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime MemberSince { get; set; }
        public IFormFile ImageUpload { get; set; }
    }
}
