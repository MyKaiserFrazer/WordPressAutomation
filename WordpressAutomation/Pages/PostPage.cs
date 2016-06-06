using OpenQA.Selenium;
using System;
/// <summary>
/// PostPage.cs
/// **Framework**
/// Helper to provide verification that blog title is accurate.
/// </summary>
namespace WordpressAutomation
{
    public class PostPage
    {
        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.ClassName("entry-title"));   // used in CreatePostTests.cs
                if (title != null)
                    return title.Text;
                return String.Empty;
            } 
        }
    }
}
