using NCRAssignment.Helpers;
using NCRAssignment.PageObject;
using NUnit.Framework;

namespace NCRAssignment
{
    [TestFixture]
    public class Tests : Base
    {
        [Test]
        public void FindLaptops()
        {
            KupujemProdajem kppage = new KupujemProdajem();
            OpenKp open = new OpenKp();

            open.OpenKP();
            kppage.CloseLoginModal();
            kppage.CookiesAccept();
            kppage.SearchOnKP("Laptop");
            kppage.ClickOnSuggestion();
            kppage.OpenSort();
            kppage.LowPriceClick();
            kppage.SearchBtnClick();
            kppage.PrintTopFiveResults();
            kppage.AssertPriceIsLowerThan(12);
        }
    }
}
