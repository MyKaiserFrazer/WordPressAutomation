using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/// <summary>
/// NewPostPage.cs
/// **Framework**
/// Selects the menu to create a new blog, fills in the title and body with some text,
/// publishes the new blog, then selects the link to view the new blog.
/// </summary>
namespace WordpressAutomation
{
    public class NewPostPage
    {
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
            var message = Driver.Instance.FindElement(By.Id("message"));
            var newPostLink = message.FindElements(By.TagName("a"))[0];
            newPostLink.Click();
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
