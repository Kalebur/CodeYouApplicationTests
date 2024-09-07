using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CodeYouApplicationTests
{
    public class SeleniumHelpers
    {
        private readonly IWebDriver _driver;
        private readonly Actions _actionsPerformer;

        public SeleniumHelpers(IWebDriver driver, Actions actionsPerformer)
        {
            _driver = driver;
            _actionsPerformer = actionsPerformer;
        }

        public void SelectDropdownItemWithText(IWebElement dropdown, string text)
        {
            var selectDropdown = new SelectElement(dropdown);
            ScrollToElement(dropdown);
            selectDropdown.SelectByText(text);
        }

        public void ScrollToElement(IWebElement element)
        {
            _actionsPerformer.ScrollToElement(element).Perform();
        }

        public void SelectInputWithText(IWebElement inputGroup, string text)
        {
            var inputItems = inputGroup.FindElements(By.XPath(".//child::span//label"));

            foreach (var inputItem in inputItems)
            {
                ScrollToElement(inputItem);
                if (inputItem.Text == text) inputItem.Click();
            }
        }
    }
}