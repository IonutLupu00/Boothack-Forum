using System.Collections.Generic;
using BoothackForum.Models.PostModel;
namespace BoothackForum.Models.ForumModel
{
    public class ForumTopicModel
    {
        public ForumListingModel Forum { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }

    }
}
