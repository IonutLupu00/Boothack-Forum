using BoothackForum.Data;
using BoothackForum.Service;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTests
{
    public class Tests
    {
        PostService postService;
        Mock<ApplicationDbContext> databaseContextMock;
        [SetUp]
        public void Setup()
        {
            postService = new PostService(databaseContextMock.Object);
        }

        [Test]
        public void Test_Post_Add_Edit_Delete()
        {
            List<Post> posts = new List<Post>();

            Assert.Pass();
        }
    }
}