using System;
using System.ComponentModel;
using BoothackForum.Models.ForumModel;

namespace BoothackForum.Models.PostModel
{
    public class PostListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int AuthorRating { get; set; }
        public string AuthorId { get; set; }
        public string DatePosted { get; set; }

       
        public bool Hidden { get; set; }
        public ForumListingModel Forum { get; set; }
        public int RepliesCount { get; set;  }
    }
}
