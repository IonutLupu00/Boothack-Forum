namespace BoothackForum.Models.ForumModel
{
    public class ForumListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int PostsCount { get; set; }
    }
}
