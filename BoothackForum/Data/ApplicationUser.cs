using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BoothackForum.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Password { get; set; }
        public string Photo { get; set; }
        public int Rating { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<Post> UserPosts { get; set; }
        public DateTime Created { get; set; }
        
    }
}
