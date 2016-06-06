using System;
using OpenQA.Selenium;
using System.Linq;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;

/// <summary>
/// Methods to support menu selection and Sample Page selection in PageTests
/// </summary>
namespace WordpressAutomation
{
    public class ListPostsPage
    {
        /// <summary>
        /// This is how we avoid creating a variable in the test
        /// </summary>
        private static int lastCount;

        /// <summary>
        /// There are two types of posts, a Page and a Post
        /// </summary>
        public enum PostType
        {
            Page,
            Posts
        }


        public static void GoTo(PostType postType)
        {
            switch (postType)
            {
                case PostType.Page:
                    LeftNavigation.Pages.AllPages.Select();
                    break;

                case PostType.Posts:
                    LeftNavigation.Posts.AllPosts.Select();
                    break;
            }
        }

        public static int PreviousPostCount
        {
            get { return lastCount; }
        }

        public static int CurrentPostCount
        {
            get { return getPostCount(); }
        }

        /// <summary>
        /// Select the post
        /// </summary>
        /// <param name="title"></param>
        public static void SelectPost(string title)
        {
            var postLink = Driver.Instance.FindElement(By.LinkText("Sample Page"));
            postLink.Click();
        }

        /// <summary>
        /// Store the count of posts in the Posts page
        /// </summary>
        public static void StoreCount()
        {
            lastCount = getPostCount();
        }

        /// <summary>
        /// Get the count of posts in the Posts page
        /// </summary>
        /// <returns></returns>
        private static int getPostCount()
        {
            var countText = Driver.Instance.FindElement(By.ClassName("displaying-num")).Text;
            return int.Parse(countText.Split(' ')[0]);      // actual text is "n items" so just get n, and convert to int and return it
        }

        public static bool DoesPostExistWithTitle(string title)
        {
            return Driver.Instance.FindElements(By.LinkText(title)).Any();
        }

        public static void TrashPost(string title)
        {
            var rows = Driver.Instance.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                ReadOnlyCollection<IWebElement> links = null;
                Driver.NoWait(() => links = row.FindElements(By.LinkText(title)));

                //for multiple 'links' or rows with the same title, go to the most recent one
                if (links.Count > 0)
                {
                    Actions action = new Actions(Driver.Instance);
                    action.MoveToElement(links[0]);     // just look at the last post that was created matching our criteria on title
                    action.Perform();                   // need to hover over, that is why we need the Actions class
                    row.FindElement(By.ClassName("submitdelete")).Click();  // find the trash button from hovering and click it
                    return;
                }
            }
        }

        public static void SearchForPost(string searchString)
        {
            var searchBox = Driver.Instance.FindElement(By.Id("post-search-input"));
            searchBox.SendKeys(searchString);

            var searchButton = Driver.Instance.FindElement(By.Id("search-submit"));
            searchButton.Click();
        }
    }
}
