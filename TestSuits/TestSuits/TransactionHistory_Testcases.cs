using AimyTest;
using AimyTest.Browsers;
using AimyTest.TestSuits;
using AimyTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestSuits.TestSuits
{
    class TransactionHistory_Testcases : TestBase
    {
        public static readonly log4net.ILog log = AimyTest.Utilities.LogHelper.GetLogger();
        private IWebDriver driver = null;
        public TransactionHistory_Testcases()
        {
            driver = ChromeBrowser.chromeDriver;
            
            driver.Navigate().GoToUrl(GlobalVariable.sURL);
        }
        [Test]
        public void TransactionHistory__TC01()
        {
            Pages.OnWhichBrowser(driver);
            Pages.LoginPage.LoginAimy(driver, "bing@cssteam.co.nz", "123123");
            driver.Navigate().GoToUrl(GlobalVariable.sURL + "Finance/RedirectType?type=XeroInvoicePage");
            Assert.AreEqual(0, Pages.TransactionHistoryPage.CompareFirstThreeRecordsOnInvoicePageWithDetail(driver));
        }

        [Test]
        public void TransactionHistory__TC02()
        {
            Pages.OnWhichBrowser(driver);
            Pages.LoginPage.LoginAimy(driver, "bing@cssteam.co.nz", "123123");
            driver.Navigate().GoToUrl(GlobalVariable.sURL + "Finance/RedirectType?type=XeroInvoicePage");
            Assert.AreEqual(0, Pages.TransactionHistoryPage.CompareFirstThreeRecordsOnCreditNotePageWithDetail(driver));
        }
    }
}
