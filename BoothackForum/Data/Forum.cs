﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoothackForum.Data
{
    public class Forum
    {
        public int ForumId { get; set; }
        public DateTime? Created { get; set; }
        

        public string Title { get; set; }
        public string Description { get; set; }
        
        public string ImageURL { get; set; }
        public virtual IEnumerable<Post> Posts { get; set; }

    }
}
