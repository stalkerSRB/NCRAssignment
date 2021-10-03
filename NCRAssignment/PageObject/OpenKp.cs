using NCRAssignment.Driver;
using OpenQA.Selenium;

namespace NCRAssignment.PageObject
{
    public class OpenKp
    {
        private readonly IWebDriver driver = WebDriver.Instance;

        public void OpenKP()
        {
            driver.Navigate().GoToUrl("https://www.kupujemprodajem.com/");
        }
    }
}
