using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;


namespace NCRAssignment.Driver
{
    public static class WebDriver
    {
        public static IWebDriver Instance { get; set; }

        public static void Initialize()
        {
            Instance = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Instance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            try
            {
                Instance.Manage().Window.Maximize();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Cleanup()
        {
            Instance?.Quit();
        }
    }
}
