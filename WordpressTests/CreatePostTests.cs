using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// CreatePostTests.cs
/// **Test**
/// The main test file for creating blog post test.
/// </summary>
namespace WordpressTests
{
    [TestClass]
    public class CreatePostTests
    {

        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

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

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
        }
    }
}
