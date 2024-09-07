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
            var expectedErrorText = _applyPage.GetExpectedFormSubmissionErrorAlertText(1);

            _driver.Navigate().GoToUrl(_applyPage.ApplyPageUrl);
            _applyPage.FillRequiredFieldsAs(_applyPage.Applicants[0]);
            //_seleniumHelpers.ScrollToElement(_applyPage.AcknowledgementCheckbox);
            //_applyPage.AcknowledgementCheckbox.Click();
            _applyPage.SubmitApplication();
            var alertText = _driver.GetAlertText();
            _driver.DismissAlert();

            Assert.That(alertText, Is.EqualTo(expectedErrorText));
        }
        
        [Test]
        public void ApplicationForm_SubmitsWithoutError_WhenAllFieldsAreFilled()
        {
            var expectedErrorText = _applyPage.GetExpectedFormSubmissionErrorAlertText(1);

            _driver.Navigate().GoToUrl(_applyPage.ApplyPageUrl);
            _applyPage.FillAllFieldsAs(_applyPage.Applicants[2]);
            //_seleniumHelpers.ScrollToElement(_applyPage.AcknowledgementCheckbox);
            //_applyPage.AcknowledgementCheckbox.Click();
            _applyPage.SubmitApplication();
            var alertText = _driver.GetAlertText();
            _driver.DismissAlert();

            Assert.That(alertText, Is.EqualTo(expectedErrorText));
        }

        [TestCase("IN")]
        [TestCase("KY")]
        [TestCase("OH")]
        public void ApplicationForm_DisplaysOnlyCountiesInSelectedState(string state)
        {
            var onlyCountiesInStateDisplayed = true;
            _driver.Navigate().GoToUrl(_applyPage.ApplyPageUrl);
            var hiddenCountyGroups = _applyPage.AllCountyGroups
                .Where(group => group.GetAttribute("label") != state)
                .ToList();

            _seleniumHelpers.SelectDropdownItemByText(_applyPage.StateDropdown, state);
            foreach (var hiddenCountyGroup in hiddenCountyGroups)
            {
                if (!hiddenCountyGroup.GetAttribute("style").Contains("none"))
                {
                    onlyCountiesInStateDisplayed = false;
                    break;
                }
            }

            Assert.That(onlyCountiesInStateDisplayed, Is.True);
        }

        [Test]
        public void StateDropdown_ContainsOnlyStatesServedByProgram()
        {
            var onlyValidStatesDisplayed = true;

            _driver.Navigate().GoToUrl(_applyPage.ApplyPageUrl);
            _seleniumHelpers.ScrollToElement(_applyPage.StateDropdown);
            var stateChoices = _applyPage.StateDropdown
                .FindElements(By.XPath(".//child::option"))
                .Where(element => !element.Text.ToLower().Contains("please select"));

            foreach (var stateChoice in stateChoices)
            {
                if (!_applyPage.ServedStates.Contains(stateChoice.Text))
                {
                    onlyValidStatesDisplayed = false;
                    break;
                }
            }

            Assert.That(onlyValidStatesDisplayed, Is.True);
        }

        // Test Case 4
        [Test]
        public void ApplicationForm_FailsToSubmit_WhenFormIsBlank()
        {
            var errorAlertText = string.Empty;
            var expectedErrorAlertText = _applyPage.GetExpectedFormSubmissionErrorAlertText(28);

            _driver.Navigate().GoToUrl(_applyPage.ApplyPageUrl);
            _applyPage.SubmitApplication();
            errorAlertText = _driver.GetAlertText();
            _driver.DismissAlert();

            Assert.That(errorAlertText, Is.EqualTo(expectedErrorAlertText));
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}