using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
/// <summary>
/// Driver.cs
/// **Framework**
/// Sets up the inital browser object that Selenium WebDriver uses to test with. Also an implicit
/// timeout value is setup for sync purposes.
/// </summary>
namespace WordpressAutomation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static void Initialize()
        {
            Instance = new FirefoxDriver();
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        public static void Close()
        {
            // Instance.Close();
        }
    }
}