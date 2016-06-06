using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests.PostsTests
{
    [TestClass]
    public class AllPostsTests : WordpressTest
    {
        // Added posts show up in all posts
        // Can trash a post
        // Can search posts

        [TestMethod]
        public void Added_Posts_Show_Up()
        {
            // Go to posts, get post count, store
            ListPostsPage.GoTo(ListPostsPage.PostType.Posts);
            ListPostsPage.StoreCount();

            // Add a new post
            NewPostPage.GoTo();
            NewPostPage.CreatePost("Added posts show up, title")
                .WithBody("Added posts show up, body")
                .Publish();

            // Go to posts, get new post count
            ListPostsPage.GoTo(ListPostsPage.PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, ListPostsPage.CurrentPostCount, "Count of posts did not increase");

            // Check for added post
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle("Added posts show up, title"));

            // Trash post (clean up)
            ListPostsPage.TrashPost("Added posts show up, title");
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostCount, "Couldn't trash post");
        }

        [TestMethod]
        public void Can_Search_Posts()
        {
            // Create a new post
            NewPostPage.GoTo();
            NewPostPage.CreatePost("Searching posts, title")
                .WithBody("Searching posts, body")
                .Publish();

            // Go to list posts
            ListPostsPage.GoTo(ListPostsPage.PostType.Posts);

            // Search for post
            ListPostsPage.SearchForPost("Searching posts, title");

            // Check that post shows up in results
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle("Searching posts, title"));

            // CleanUp (Trash post) 
            ListPostsPage.TrashPost("Searching posts, title");
        }
    }
}
