using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace AimyTest.Booking_Pages
{
    class BookingPages_Wizard8 : MyElelment
    {
        public BookingPages_Wizard8()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);
        }
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div[4]/a")]
        public IWebElement btnBackToDashBoard { get; set; }

       [FindsBy(How = How.XPath, Using = "html/body/div[3]/div/div/div[2]/div[3]/div/div[2]/div/div[3]/table/tbody/tr[2]/td[8]")]
        public IWebElement elePending { get; set; }


        private void DoScrollTo(By by)
        {
            System.Drawing.Point point = ((RemoteWebElement)Common.driver.FindElement(by)).LocationOnScreenOnceScrolledIntoView;
        }

        public bool StepsForBookingWizard8()
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(btnBackToDashBoard);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            return ValidateDashBoard(); 
        }

        private bool ValidateDashBoard()
        {
            WebDriverWait wait = new WebDriverWait(Common.driver, TimeSpan.FromSeconds(5));
            wait.PollingInterval = TimeSpan.FromSeconds(2);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("html/body/div[3]/div/div/div[2]/div[3]/div/div[2]/div/div[3]/table/tbody/tr[2]/td[8]")));

            IWebElement ele = Common.driver.FindElement(
                By.XPath("html/body/div[3]/div/div/div[2]/div[3]/div/div[2]/div/div[3]/table/tbody/tr[2]/td[8]"));

            if (ele != null)
                return true;
            else return false;
        }
    }
}
