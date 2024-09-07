using OpenQA.Selenium;

namespace CodeYouApplicationTests
{
    public static class IWebDriverExtensions
    {
        public static string GetAlertText(this IWebDriver driver)
        {
            return driver.SwitchTo().Alert().Text;
        }

        public static void DismissAlert(this IWebDriver driver)
        {
            driver.SwitchTo().Alert().Dismiss();
        }
    }
}
