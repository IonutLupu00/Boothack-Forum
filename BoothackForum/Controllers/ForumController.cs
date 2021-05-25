using BoothackForum.Data;
using BoothackForum.Models.ForumModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BoothackForum.Models.PostModel;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BoothackForum.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly IPost _postService;
        public ForumController(IForum forumService, IPost postService)
        {
            _postService = postService;
            _forumService = forumService;
        }
        public IActionResult Index()
        {
            IEnumerable<ForumListingModel> forums = _forumService.GetAll()
                .Select(forum => new ForumListingModel 
            {
                Id = forum.ForumId,
                Name = forum.Title,
                Description = forum.Description,
                ImageURL = forum.ImageURL
            });
            var model = new ForumIndexModel {
                ForumList = forums
            };
            return View(model);
        }

        public IActionResult Topic(int id, string searchQuery)
        {
            Forum forum = _forumService.GetById(id);
            var posts = new List<Post>();
           
            posts = _postService.GetFilteredPosts(forum, searchQuery).ToList();
                       

            var postListings = posts.Select(post => new PostListingModel
            {
                Id = post.Postid,
                AuthorName = post.User.UserName ?? "Unknown Author",
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = _postService.GetNumberOfAvailableReplies(post.Postid),
                Forum = BuildForumListing(post),
                Hidden = post.Hidden
                
            });



            var model = new ForumTopicModel
            {
                Posts = postListings,
                Forum = BuildForumListing(forum),
                SearchQuery = searchQuery,
                PostsCount = _postService.GetNumberOfAvailablePosts(id)
            };
             
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(int id, string searchQuery)
        {
            return RedirectToAction("Topic", new { id, searchQuery });
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var model = new NewForumModel { };
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddForum(NewForumModel newForum)
        {
            var forum = new Forum
            {
                Title = newForum.Name,
                Description = newForum.Description,
                Created = newForum.Created
            };

            await _forumService.Add(forum);
            return RedirectToAction("Index", "Forum");
        }

        private ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;

            return BuildForumListing(forum);
        }

        private ForumListingModel BuildForumListing(Forum forum)
        {

            return new ForumListingModel
            {
                Id = forum.ForumId,
                Name = forum.Title,
                Description = forum.Description,
                ImageURL = forum.ImageURL,
                PostsCount = forum.Posts.Count()
            };
        }
    }
}
