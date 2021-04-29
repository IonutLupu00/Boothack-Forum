using BoothackForum.Data;
using BoothackForum.Models.ForumModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BoothackForum.Models.PostModel;
using System;


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
                Description = forum.Description
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
                RepliesCount = post.Replies.Count(),
                Forum = BuildForumListing(post)
            });



            var model = new ForumTopicModel
            {
                Posts = postListings,
                Forum = BuildForumListing(forum),
                SearchQuery = searchQuery
            };
             
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(int id, string searchQuery)
        {
            return RedirectToAction("Topic", new { id, searchQuery });
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
                ImageURL = forum.ImageURL
            };
        }
    }
}
