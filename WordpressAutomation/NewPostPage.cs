using OpenQA.Selenium;
using System;
using System.Threading;
/// <summary>
/// NewPostPage.cs
/// **Framework**
/// Methods to support blog post tests and page tests.
/// </summary>
namespace WordpressAutomation
{
    public class NewPostPage
    {
        public static String Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.Id("title"));    // used in PageTests.cs
                if (title != null)
                    return title.GetAttribute("value");
                return string.Empty;
            }
        }

        public static void GoTo()
        {
            var menuPosts = Driver.Instance.FindElement(By.Id("menu-posts"));
            menuPosts.Click();

            var addNew = Driver.Instance.FindElement(By.LinkText("Add New"));
            addNew.Click();
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public static void GoToNewPost()
        {
            var message = Driver.Instance.FindElement(By.Id("message"));    // View the new post just created.
            var newPostLink = message.FindElements(By.TagName("a"))[0];
            newPostLink.Click();
        }

        /// <summary>
        /// Used in CreatePostTests.cs to to ensue the page is in Edit mode
        /// </summary>
        /// <returns>string</returns>
        public static string Header()
        {
                var header = Driver.Instance.FindElement(By.XPath("//div[@id='wpbody-content']/div[@class='wrap']/h1[contains(text(),'Edit Page')]"));
                if (header.Text == "Edit Page Add New")
                    return header.Text;     // used in PageTests.cs
                else return string.Empty;
         }
    }

    public class CreatePostCommand
    {
        private readonly string title;
        private string body;

        public CreatePostCommand(string title)
        {
            this.title = title;
        }

        public CreatePostCommand WithBody(string body)
        {
            this.body = body;
            return this;
        }

        public void Publish()
        {
            Driver.Instance.FindElement(By.Id("title")).SendKeys(title);

            Driver.Instance.FindElement(By.Id("content")).SendKeys(body);
            //Driver.Instance.SwitchTo().Frame("content_ifr");
            //Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);
            //Driver.Instance.SwitchTo().DefaultContent();

            Driver.Instance.FindElement(By.Id("publish")).Click();
            Thread.Sleep(2000); // wait some time for the publish to process
        }
    }
}
