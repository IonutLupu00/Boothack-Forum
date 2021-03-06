using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoothackForum.Data
{
    public interface IPost
    {
        public Post GetById(int id);
        public IEnumerable<Post> GetAll();
        public IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery);
        public IEnumerable<Post> GetFilteredPosts(string searchQuery);
        public IEnumerable<Post> GetPostsByForum(int id);
        public IEnumerable<Post> GetLatestPosts(int number);
        public int GetNumberOfAvailablePosts(int forumId);
        public int GetNumberOfAvailableReplies(int postId);
        public Task Add(Post post);
        public Task Delete(int id);
        public Task EditPostContent(int id, string content);
        public Task AddReply(PostReply reply);
        
        
    }
}
