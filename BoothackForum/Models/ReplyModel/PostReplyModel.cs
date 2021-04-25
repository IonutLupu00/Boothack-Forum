﻿using System;

namespace BoothackForum.Models.ReplyModel
{
    public class PostReplyModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int AuthorRating { get; set; }
        public string AuthorId { get; set; }
        public string AuthorImageURL { get; set; }
        public DateTime Created { get; set; }
        public string ReplyContent { get; set; }
        public int PostId { get; set; }
    }
}
