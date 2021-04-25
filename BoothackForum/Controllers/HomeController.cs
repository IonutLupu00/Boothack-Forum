using BoothackForum.Data;
using BoothackForum.Models;
using BoothackForum.Models.ForumModel;
using BoothackForum.Models.HomeModel;
using BoothackForum.Models.PostModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace BoothackForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPost _postService;
        private readonly IForum _forumService;
        public HomeController(ILogger<HomeController> logger, IPost postService, IForum forumService)
        {
            _postService = postService;
            _forumService = forumService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = BuildHomeIndexModel();
            return View(model);
        }

        private HomeIndexModel BuildHomeIndexModel()
        {
            var latestPosts = _postService.GetLatestPosts(10);

            var posts = latestPosts.Select(post => new PostListingModel
            {
                Id = post.Postid,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorRating = post.User.Rating,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = GetForumFromPost(post)
            }) ;

            return new HomeIndexModel
            {
                LatestPosts = posts,
                SearchQuery = ""
            };
        }

        private ForumListingModel GetForumFromPost(Post post)
        {
            var forum = post.Forum;
            return new ForumListingModel
            {
                Id = forum.ForumId,
                Name = forum.Title,
                ImageURL = forum.ImageURL
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
