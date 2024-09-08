using OpenQA.Selenium;

namespace CodeYouApplicationTests.Extensions
{
    public static class IWebElementExtensions
    {
        private static IWebDriver? _cachedDriver;

        public static void ClickViaJavaScript(this IWebElement element)
        {
            if (_cachedDriver is null)
            {
                var elementDriver = element.GetType().GetProperty("WrappedDriver")?.GetValue(element);
                if (elementDriver is null)
                {
                    throw new NotFoundException($"{nameof(element)} does not have a web driver.");
                }
                _cachedDriver = elementDriver as IWebDriver;
            }

            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)_cachedDriver!;
            javaScriptExecutor.ExecuteScript("arguments[0].click();", element);
        }
    }
}
