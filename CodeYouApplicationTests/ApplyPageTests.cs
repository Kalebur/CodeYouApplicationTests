using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CodeYouApplicationTests
{
    public class ApplyPageTests
    {
        private IWebDriver _driver;
        private ApplyPage _applyPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _applyPage = new ApplyPage(_driver);
        }

        [Test]
        public void ApplicationForm_ContainsExpectedIntroText()
        {
            _driver.Navigate().GoToUrl(_applyPage.Url);

            Assert.That(_applyPage.IntroText.Text, Is.EqualTo(_applyPage.ExpectedIntroText));
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}