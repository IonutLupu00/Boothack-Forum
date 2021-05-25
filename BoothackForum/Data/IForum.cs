using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoothackForum.Data
{
    public interface IForum
    {
        Forum GetById(int id);
        Forum GetForumByPost(Post post);
        IEnumerable<Forum> GetAll();
        IEnumerable<ApplicationUser> GetAllActiveUsers();

        Task Add(Forum forum);
        Task Delete(int forumId);
        Task UpdateForumTitle(int forumId, string newTitle);
        Task UpdateForumDescription(int forumId, string newDescription);
        
    }
}
