using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BoothackForum.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Password { get; set; }
        public string Photo { get; set; }
        public int Rating { get; set; }

        public virtual ICollection<Post> UserPosts { get; set; }
        public DateTime Created { get; set; }
    }
} 
