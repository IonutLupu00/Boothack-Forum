using BoothackForum.Data;
using BoothackForum.Models.ForumModel;
using BoothackForum.Models.PostModel;
using BoothackForum.Models.SearchModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BoothackForum.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPost _postService;
        public SearchController(IPost postService)
        {
            _postService = postService;
        }

        
        public IActionResult Results(string searchQuery)
        {
            var posts = _postService.GetFilteredPosts(searchQuery);

            var areNoResults = (!string.IsNullOrEmpty(searchQuery) && !posts.Any());


             var postListings = posts.Select(post => new PostListingModel
            {
                Id = post.Postid,
                AuthorName = post.User.UserName ?? "Unknown Author",
                AuthorId = post.User.Id ?? "0",
                AuthorRating = post.User.Rating,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = BuildForumListing(post)
            });

            var model = new SearchResultModel
            {
                Posts = postListings,
                SearchQuery = searchQuery,
                SearchResultNull = areNoResults
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Results", new { searchQuery });
        }

        private ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;

            return new ForumListingModel
            {
                Id = forum.ForumId,
                Name = forum.Title,
                Description = forum.Description,
                ImageURL = forum.ImageURL
            };
        }

        
    }
}
