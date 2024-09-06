using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace CodeYouApplicationTests
{
    public class ApplyPageTests
    {
        private IWebDriver _driver;
        private ApplyPage _applyPage;
        private SeleniumHelpers _seleniumHelpers;
        private Actions _actionsPerformer;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _actionsPerformer = new Actions(_driver);
            _seleniumHelpers = new SeleniumHelpers(_driver, _actionsPerformer);
            _applyPage = new ApplyPage(_driver, _seleniumHelpers);
        }

        [Test]
        public void ApplicationForm_ContainsExpectedIntroText()
        {
            _driver.Navigate().GoToUrl(_applyPage.ApplyPageUrl);

            Assert.That(_applyPage.IntroText.Text, Is.EqualTo(_applyPage.ExpectedIntroText));
        }

        [Test]
        public void ApplicationForm_SubmitsWithoutError_WhenAllRequiredFieldsAreFilled()
        {
            _driver.Navigate().GoToUrl(_applyPage.ApplyPageUrl);

            _applyPage.FillRequiredFieldsAs(_applyPage.Applicants[0]);
            _seleniumHelpers.ScrollToElement(_applyPage.AcknowledgementCheckbox);
            _applyPage.AcknowledgementCheckbox.Click();

            //_applyPage.SubmitApplication();
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}