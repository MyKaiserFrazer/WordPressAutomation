using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests
{
    /// <summary>
    /// Test the Pages functionality, which is similar to Post tests.
    /// </summary>
    [TestClass]
    public class PageTests : WordpressTest
    {
        [TestMethod]
        public void Can_Edit_A_Page()
        {
            ListPostsPage.GoTo(PostType.Page);       // general purpose class this will work for both posts and pages
            ListPostsPage.SelectPost("Sample Page");    // or you could add an index [0] or [1] for the 1st or 2nd post of that page

            //Assert.IsTrue(NewPostPage.IsInEditMode(), "Wasn't in edit mode");
            Assert.AreEqual("Edit Page Add New", NewPostPage.Header(), "Header did not match");
            Assert.AreEqual("Sample Page", NewPostPage.Title, "Title did not match");
        }
    }
}
