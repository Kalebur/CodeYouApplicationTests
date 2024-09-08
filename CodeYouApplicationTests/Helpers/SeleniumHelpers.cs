using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CodeYouApplicationTests.Helpers
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

        public void SelectDropdownItemByText(IWebElement dropdown, string text)
        {
            var selectDropdown = new SelectElement(dropdown);
            ScrollToElement(dropdown);
            selectDropdown.SelectByText(text);
        }

        public void ScrollToElement(IWebElement element)
        {
            _actionsPerformer.ScrollToElement(element).Perform();
        }

        public void SelectInputByText(IWebElement inputGroup, string text)
        {
            var inputItems = inputGroup.FindElements(By.XPath(".//child::span//label"));

            foreach (var inputItem in inputItems)
            {
                if (inputItem.Text == text)
                {
                    ScrollToElement(inputItem);
                    inputItem.Click();
                }
            }
        }

        public void SelectElementByIndex(IList<IWebElement> elements, int index)
        {
            elements[index].Click();
        }

        public int GetCountOfSelectedElements(IList<IWebElement> elements)
        {
            return elements.Where(element => element.Selected).Count();
        }
    }
}