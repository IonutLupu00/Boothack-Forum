using BoothackForum.Data;
using BoothackForum.Models.PostModel;
using BoothackForum.Models.ReplyModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BoothackForum.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly IForum _forumService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _singInManager;
        public PostController(IPost postService, IForum forumService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> singInManager)
        {
            _userManager = userManager;
            _forumService = forumService;
            _postService = postService;
            _singInManager = singInManager;
        }
        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);
            PostIndexModel model;
            var replies = BuildPostReplies(post.Replies);
            if (post.User != null)
            {
                model = new PostIndexModel
                {
                    Id = post.Postid,
                    Title = post.Title,
                    AuthorId = post.User.Id,
                    AuthorName = post.User.UserName,
                    AuthorImageURL = post.User.Photo,
                    AuthorRating = post.User.Rating,
                    Created = post.Created,
                    PostContent = post.Content,
                    Replies = replies,
                    ForumName = post.Forum.Title,
                    ForumId = post.Forum.ForumId,
                    IsAdmin = false,
                    IsAdminViewer = User.IsInRole("Admin"),
                    RepliesCount = _postService.GetNumberOfAvailableReplies(id)
                };
            }
            else
            {
                model = new PostIndexModel
                {
                    Id = post.Postid,
                    Title = post.Title,
                    AuthorId = null,
                    AuthorName = "Unknown Author",
                    AuthorImageURL = null,
                    AuthorRating = 0,
                    Created = post.Created,
                    PostContent = post.Content,
                    Replies = replies,
                    ForumName = post.Forum.Title,
                    ForumId = post.Forum.ForumId,
                    IsAdmin = IsAuthorAdmin(post.User),
                    IsAdminViewer = User.IsInRole("Admin"),
                    RepliesCount = _postService.GetNumberOfAvailableReplies(id)
                };
            }


            return View(model);
        }

       

        [Authorize]
        public IActionResult Create(int id)
        {

            //forum id
            var forum = _forumService.GetById(id);

            var model = new NewPostModel
            {  
                ForumName = forum.Title,
                ForumId = forum.ForumId,
                ForumImageURL = forum.ImageURL,
                AuthorName = User.Identity.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user =  _userManager.FindByIdAsync(userId).Result;
            Post post = BuildPost(model, user);
            if (!string.IsNullOrEmpty(model.Content))
            {
                await _postService.Add(post);
                return RedirectToAction("Index", "Post", new { id = post.Postid });
            }
            else
                return RedirectToAction("Topic", "Forum", new {id = model.ForumId , searchQuery = ""});
                

            
        }

        
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = _postService.GetById(id);
            await _postService.Delete(id);

            return RedirectToAction("Topic", "Forum", new { id = _forumService.GetForumByPost(post).ForumId});
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyModel { 
                Id = reply.PostReplyId,
                AuthorName = reply.User.UserName,
                AuthorId = reply.User.Id,
                AuthorImageURL = reply.User.Photo,
                AuthorRating = reply.User.Rating,
                Created = reply.Created,
                Content = reply.Content,
                IsAdmin = IsAuthorAdmin(reply.User)
            });
        }
        private Post BuildPost(NewPostModel model, ApplicationUser user)
        {
            var forum = _forumService.GetById(model.ForumId);

            return new Post
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now,
                User = user,
                Forum = forum,
                Hidden = false

            };
        }
        private bool IsAuthorAdmin(ApplicationUser user)
        {
            return _userManager.GetRolesAsync(user).Result.Contains("Admin");
        }
    }
}
