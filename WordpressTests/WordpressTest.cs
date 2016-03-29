using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests
{
    public class WordpressTest
    {
        /// <summary>
        /// WordpressTest.cs
        /// **Tests**
        /// abstracts away from each individual test module and provides [TestInitialize]
        /// and [TestCleanup] here to inherit from.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
            LoginPage.GoTo();
            LoginPage.LoginAs("admin").WithPassword("test123").Login();
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
        }
    }
}
