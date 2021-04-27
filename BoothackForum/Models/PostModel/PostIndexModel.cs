using BoothackForum.Models.ReplyModel;
using System;
using System.Collections.Generic;

namespace BoothackForum.Models.PostModel
{
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int AuthorRating { get; set; }
        public string AuthorImageURL { get; set; }
        public DateTime Created { get; set; }
        public string PostContent { get; set; }
        public IEnumerable<PostReplyModel> Replies { get; set; }
        public bool IsAdmin { get; set; }

        public int ForumId { get; set; }
        public string ForumName { get; set; }
    }
}
