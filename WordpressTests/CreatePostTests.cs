using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;
/// <summary>
/// CreatePostTests.cs
/// **Test**
/// The main test runner file for creating blog post test.
/// Selects the menu to create a new blog, fills in the title and body with some text,
/// publishes the new blog, selects the link to view the new blog and finally verifies
/// the title of the new blod post is correct.
/// </summary>
namespace WordpressTests
{
    [TestClass]
    public class CreatePostTests : WordpressTest
    {
        [TestMethod]
        public void Can_Create_A_Basic_Post()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("admin").WithPassword("test123").Login();

            NewPostPage.GoTo();
            NewPostPage.CreatePost("This is the test post title").WithBody("Hi this is the body").Publish();

            NewPostPage.GoToNewPost();

            Assert.AreEqual(PostPage.Title, "This is the test post title", "Title did not match new post.");
        }
    }
}
