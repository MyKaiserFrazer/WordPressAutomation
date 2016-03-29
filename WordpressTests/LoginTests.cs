using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;
/// <summary>
/// LoginTests.cs
/// **Test**
/// Test the login page and verify reaching the landing page.
/// </summary>
namespace WordpressTests
{
    [TestClass]
    public class LoginTests : WordpressTest
    {
        [TestMethod]
        public void Admin_User_Can_Login()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("admin").WithPassword("test123").Login();

            Assert.IsTrue(DashboardPage.IsAt, "Failed to login.");
        }
    }
}
