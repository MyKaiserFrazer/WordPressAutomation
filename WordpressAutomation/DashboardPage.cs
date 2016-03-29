using OpenQA.Selenium;
/// <summary>
/// DashboardPage.cs
/// **Framework**
/// <example>Provides the header text for verification that the landing page appears post login</example>
/// </summary>
namespace WordpressAutomation
{
    public class DashboardPage
    {
        public static bool IsAt
        {
            get
            {
                var h1s = Driver.Instance.FindElements(By.TagName("h1"));
                if (h1s.Count > 0)
                    return h1s[0].Text == "Dashboard";
                return false;
            }
        }
    }
}
