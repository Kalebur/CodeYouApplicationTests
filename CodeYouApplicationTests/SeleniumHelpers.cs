using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CodeYouApplicationTests
{
    public class SeleniumHelpers
    {
        private readonly IWebDriver _driver;

        public SeleniumHelpers(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SelectDropdownItemWithText(IWebElement dropdown, string text)
        {
            var selectDropdown = new SelectElement(dropdown);
            selectDropdown.SelectByText(text);
        }

        public void ScrollToElement(IWebElement element)
        {
            var act = new Actions(_driver);

            act.ScrollToElement(element).Perform();
        }

        public void SelectInputWithText(IWebElement inputGroup, string text)
        {
            var checkboxes = inputGroup.GetAllChildrenBy(By.XPath("child::span//label"));

            foreach (var checkbox in checkboxes)
            {
                if (checkbox.Text == text) checkbox.Click();
            }
        }
    }
}