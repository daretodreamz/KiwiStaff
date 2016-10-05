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

namespace AimyTest.Booking_Pages_BSC_ASC
{
    public class BookingPages_Wizard8 : MyElelment
    {
       
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div[4]/a")]
        private IWebElement btnBackToDashBoard { get; set; }

       [FindsBy(How = How.XPath, Using = "html/body/div[3]/div/div/div[2]/div[3]/div/div[2]/div/div[3]/table/tbody/tr[2]/td[8]")]
        private IWebElement elePending { get; set; }


        private void DoScrollTo(IWebDriver driver, By by)
        {
            System.Drawing.Point point = ((RemoteWebElement)driver.FindElement(by)).LocationOnScreenOnceScrolledIntoView;
        }

        public bool StepsForBookingWizard8(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnBackToDashBoard);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            return ValidateDashBoard(driver); 
        }

        private bool ValidateDashBoard(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.PollingInterval = TimeSpan.FromSeconds(2);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("html/body/div[3]/div/div/div[2]/div[3]/div/div[2]/div/div[3]/table/tbody/tr[2]/td[8]")));

            IWebElement ele = driver.FindElement(
                By.XPath("html/body/div[3]/div/div/div[2]/div[3]/div/div[2]/div/div[3]/table/tbody/tr[2]/td[8]"));

            if (ele != null)
                return true;
            else return false;
        }
    }
}
