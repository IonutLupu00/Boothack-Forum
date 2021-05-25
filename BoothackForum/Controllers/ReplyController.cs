using BoothackForum.Data;
using BoothackForum.Models.ReplyModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoothackForum.Controllers
{
    public class ReplyController : Controller
    {
        private readonly IPost _postService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReplyController(IPost postService, UserManager<ApplicationUser> userManager)
        {
            _postService = postService;
            _userManager = userManager;
        }

        public IActionResult Create(int id)
        {
            var forum = _postService.GetById(id).Forum;

            var model = new PostReplyModel
            {
                AuthorName = User.Identity.Name,
                PostId = id,
                PostTitle = _postService.GetById(id).Title

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReply(PostReplyModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;
            PostReply reply = BuildReply(model, user);

            if (!string.IsNullOrEmpty(reply.Content))
            {
                await _postService.AddReply(reply);
               
            }
            return RedirectToAction("Index", "Post", new { id = reply.Post.Postid });

        }

        private PostReply BuildReply(PostReplyModel model, ApplicationUser user)
        {
            var post = _postService.GetById(model.PostId);

            return new PostReply
            {
                Content = model.Content,
                Created = DateTime.Now,
                User = user,
                Post = post

            };
        }
    }
}
