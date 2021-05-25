using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoothackForum.Data;
using BoothackForum.Models.ForumModel;
using Microsoft.EntityFrameworkCore;

namespace BoothackForum.Service
{
    public class ForumService : IForum
    {
        private readonly ApplicationDbContext _context;
        public ForumService(ApplicationDbContext context)
        {
            _context = context;
        }

        

        async Task IForum.Add(Forum forum)
        {
            _context.Add(forum);
            await _context.SaveChangesAsync();
        }

        Task IForum.Delete(int forumId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Forum> IForum.GetAll()
        {
            return _context.Forums.Include(forum => forum.Posts);
        }

        IEnumerable<ApplicationUser> IForum.GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        
        Forum IForum.GetForumByPost(Post post)
        {
            var forum = _context.Forums.Where(f => f.Posts.Contains(post))
                .Include(f => f.Posts)
                    .ThenInclude(p => p.User)
                .Include(f => f.Posts)
                    .ThenInclude(p => p.Replies)
                        .ThenInclude(r => r.User)
                .FirstOrDefault();
            return forum;
        }

        Forum IForum.GetById(int id)
        {
            var forum = _context.Forums.Where(f => f.ForumId == id)
                .Include(f => f.Posts)
                    .ThenInclude(p => p.User)
                .Include(f => f.Posts)
                    .ThenInclude(p => p.Replies)
                        .ThenInclude(r => r.User)
                .FirstOrDefault();
            return forum;
        }

        Task IForum.UpdateForumDescription(int forumId, string newDescription)
        {
            throw new NotImplementedException();
        }

        Task IForum.UpdateForumTitle(int forumId, string newTitle)
        {
            throw new NotImplementedException();
        }

        
    }
}
