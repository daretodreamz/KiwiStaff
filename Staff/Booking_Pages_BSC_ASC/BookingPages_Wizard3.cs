using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace AimyTest.Booking_Pages_BSC_ASC
{
    public class BookingPages_Wizard3 : MyElelment
    {
        
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div[1]/div/div[1]/label[1]")]
        private IWebElement btnRegularBooking { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div[1]/div/div[2]/label[2]")]
        private IWebElement btnTerms { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div[1]/div/div[7]/button[2]")]
        private IWebElement btnNext { get; set; }


        private void DoScrollTo(IWebDriver driver, By by)
        {
            System.Drawing.Point point = ((RemoteWebElement)driver.FindElement(by)).LocationOnScreenOnceScrolledIntoView;
        }

        public void StepsForBookingWizard3(IWebDriver driver)
        {
            AimyClick(driver, btnRegularBooking);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnTerms);
            Thread.Sleep(2000);

            AimyClick(driver, btnNext);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
        }
    }
}
