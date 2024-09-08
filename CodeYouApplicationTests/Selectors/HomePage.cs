using OpenQA.Selenium;

namespace CodeYouApplicationTests.Selectors
{
    public class HomePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string HomePageUrl => "https://code-you.org/";
        public string ApplyPageUrl => "https://code-you.org/apply/";

        public IWebElement ApplyPageLink => _driver.FindElement(By.Id("menu-item-44"));
    }
}
