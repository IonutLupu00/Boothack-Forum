using BoothackForum.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BoothackForum.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetPostsByForum(int id)
        {
            return _context.Forums.Where(forum => forum.ForumId == id)
                .First()
                .Posts; 
        }
        
        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();

        }

        async Task IPost.AddReply(PostReply reply)
        {
            _context.Add(reply);
            await _context.SaveChangesAsync();
        }

        async Task IPost.Delete(int id)
        {
            _context.Posts.Where(p => p.Postid == id).FirstOrDefault().Hidden = true;
            
            await _context.SaveChangesAsync();
        }

        Task IPost.EditPostContent(int id, string content)
        {
            throw new System.NotImplementedException();
        }

       public IEnumerable<Post> GetAll()
        {
            return _context.Posts
                .Include(post => post.User)
                .Include(post => post.Replies)
                    .ThenInclude(reply => reply.User)
                .Include(post => post.Forum);
        }

       public Post GetById(int id)
        {
            return _context.Posts.Where(post => post.Postid == id)
                .Include(post => post.User)
                .Include(post => post.Replies)
                    .ThenInclude(reply => reply.User)
                .Include(post => post.Forum)
                .First();
        }

        IEnumerable<Post> IPost.GetFilteredPosts(Forum forum, string searchQuery)
        {
            var searchString = searchQuery ?? "";
            searchString = searchString.ToLower();

            return string.IsNullOrEmpty(searchString) ? forum.Posts :
            forum.Posts
            .Where(post => post.Title.ToLower()
            .Contains(searchString)
            || post.Content.ToLower().Contains(searchString) 
            || post.User.UserName.ToLower().Contains(searchString));                               
        }

        IEnumerable<Post> IPost.GetLatestPosts(int number)
        {
            return GetAll().OrderByDescending(post => post.Created).Take(number);
        }

        IEnumerable<Post> IPost.GetFilteredPosts(string searchQuery)
        {
            var searchString = searchQuery ?? "";
            searchString = searchString.ToLower();

            return GetAll()
                .Where(post => post.Title.ToLower()
                .Contains(searchString)
                || post.Content.ToLower().Contains(searchString)
                || post.User.UserName.ToLower().Contains(searchString));
        }

        int IPost.GetNumberOfAvailablePosts(int forumId)
        {
            int numerOfPosts = 0;
            foreach(var post in _context.Posts.Where(p => p.Forum.ForumId == forumId))
            {
                if (post.Hidden == false)
                    numerOfPosts++;
            }
            return numerOfPosts;
        }

        int IPost.GetNumberOfAvailableReplies(int postId)
        {
            int numberOfReplies = 0;
            foreach (var reply in _context.Replies.Where(r => r.Post.Postid == postId))
            {
                if (reply.Hidden == false)
                    numberOfReplies++;
            }
            return numberOfReplies;
        }
    }
}
