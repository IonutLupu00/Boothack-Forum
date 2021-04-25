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

        Task IPost.AddReply(PostReply reply)
        {
            throw new System.NotImplementedException();
        }

        Task IPost.Delete(int id)
        {
            throw new System.NotImplementedException();
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

        IEnumerable<Post> IPost.GetFilteredPosts(string searchQuery)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Post> IPost.GetLatestPosts(int number)
        {
            return GetAll().OrderByDescending(post => post.Created).Take(number);
        }
    }
}
