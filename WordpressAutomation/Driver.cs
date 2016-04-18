using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;
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

        public static string BaseAddress
        {
            get { return "http://localhost:2329/";  }  // Refactor: maybe read this from a config file later on
        }

        public static void Initialize()
        {
            Instance = new FirefoxDriver();
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        public static void Close()
        {
            // Instance.Close();
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)(timeSpan.TotalSeconds * 1000));
        }
    }
}