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
    public class BookingPages_Wizard7 : MyElelment
    {
        
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // select one of the children
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div[4]/div/div[1]/div[4]/button[2]")]
        private IWebElement btnFinish { get; set; }

        private void DoScrollTo(IWebDriver driver, By by)
        {
            System.Drawing.Point point = ((RemoteWebElement)driver.FindElement(by)).LocationOnScreenOnceScrolledIntoView;
        }

        public BookingPages_Wizard8 StepsForBookingWizard7(IWebDriver driver)
        {
            // need to wait for the page fully loaded
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(3000));
            wait.Until(drv => ((IJavaScriptExecutor)drv).ExecuteScript("return document.readyState").Equals("complete"));
            DoScrollTo(driver, By.XPath("html/body/div[3]/div[4]/div/div[4]/div/div[1]/div[4]/button[2]"));
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnFinish);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            return  new BookingPages_Wizard8();
        }
    }
}
