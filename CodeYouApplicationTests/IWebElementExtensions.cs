using OpenQA.Selenium;

namespace CodeYouApplicationTests
{
    public static class IWebElementExtensions
    {
        public static IList<IWebElement> GetAllChildren(this IWebElement element)
        {
            return element.FindElements(By.XPath("child::"));
        }

        public static IList<IWebElement> GetAllChildrenBy(this IWebElement element, By searchType)
        {
            return element.FindElements(searchType);
        }
    }
}
