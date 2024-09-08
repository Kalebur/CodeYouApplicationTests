using CodeYouApplicationTests.Helpers;
using CodeYouApplicationTests.Selectors;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace CodeYouApplicationTests
{
    public class HomePageTests
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private SeleniumHelpers _seleniumHelpers;
        private Actions _actionsPerformer;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _homePage = new HomePage(_driver);
            _actionsPerformer = new Actions(_driver);
            _seleniumHelpers = new SeleniumHelpers(_driver, _actionsPerformer);
        }

        // Test Case 3
        [Test]
        public void HomePage_ContainsLinkThat_RedirectsToApplyPage()
        {
            _driver.Navigate().GoToUrl(_homePage.HomePageUrl);
            _seleniumHelpers.ScrollToElement(_homePage.ApplyPageLink);
            _homePage.ApplyPageLink.Click();
            var currentUrl = _driver.Url;

            Assert.That(currentUrl, Is.EqualTo(_homePage.ApplyPageUrl));
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
