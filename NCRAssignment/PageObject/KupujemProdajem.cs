using NCRAssignment.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NCRAssignment.PageObject
{
    public class KupujemProdajem
    {
        const int euroValue = 118;

        private readonly IWebDriver driver = WebDriver.Instance;

        private IWebElement Search => driver.FindElement(By.Id("searchKeywordsInput"));

        private IWebElement Searchbox => driver.FindElement(By.ClassName("kpACListItemLabel"));

        private IWebElement CloseBtn => driver.FindElement(By.ClassName("kpBoxCloseButton"));

        private IWebElement CookieBtn => driver.FindElement(By.Name("i-understand"));

        private IEnumerable<IWebElement> Items => driver.FindElements(By.ClassName("nameSec"));

        private IEnumerable<IWebElement> ItemsPrice => driver.FindElements(By.CssSelector("span.adPrice"));

        private IWebElement Sort => driver.FindElement(By.CssSelector("#orderSecondSelection > div > div.choiceLabelHolder > div.choiceLabel"));

        private IWebElement HighPrice => driver.FindElement(By.CssSelector("div.uiMenuItem[data-text='Skuplje']"));

        private IWebElement LowPrice => driver.FindElement(By.CssSelector("div.uiMenuItem[data-text='Jeftinije']"));

        private IWebElement SearchBtn => driver.FindElements(By.CssSelector("input[name='submit[search]']"))[1];


        public void CloseLoginModal()
        {
            CloseBtn.Click();
        }

        public void SearchOnKP(string term)
        {
            Search.Clear();
            Search.SendKeys(term);
        }

        public void ClickOnSuggestion()
        {
            Searchbox.Click();
        }

        public void OpenSort()
        {
            Sort.Click();
        }

        public void HightPriceClick()
        {
            HighPrice.Click();
        }
        public void LowPriceClick()
        {
            LowPrice.Click();
        }

        public void SearchBtnClick()
        {
            SearchBtn.Click();
        }

        public void PrintTopFiveResults()
        {
            var mostExpensive = Items.Take(5);
            foreach (var item in mostExpensive)
            {
                Console.WriteLine(item.FindElement(By.ClassName("fixedHeight")).Text);
            }
        }

        public void AssertPriceIsLowerThan(double maxPrice)
        {
            var mostChipest = ItemsPrice.Take(5);
            foreach (var item in mostChipest)
            {
                if (item.Text.Contains("din"))
                {
                    string price = item.Text.Substring(0, item.Text.IndexOf(" "));
                    price.Substring(0, price.IndexOf(""));
                    var totalPrice = double.Parse(price.Replace(".", ""));
                    Assert.IsTrue(totalPrice < maxPrice * euroValue, "Cena je veca od " + maxPrice * euroValue + "din, dobijena cena je: " + totalPrice + "din");
                }
                else if (item.Text.Contains("€"))
                {
                    string price = item.Text.Substring(0, item.Text.IndexOf(" "));
                    var totalPrice = double.Parse(price.Replace(",", ""));
                    Assert.IsTrue(totalPrice < maxPrice, "Cena je veca od " + maxPrice + "e, dobijena cena je: " + totalPrice + "e");
                }
            }

        }

        public void CookiesAccept()
        {
            CookieBtn.Click();
        }

    }
}
