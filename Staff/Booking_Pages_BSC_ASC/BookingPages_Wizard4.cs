using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace AimyTest.Booking_Pages_BSC_ASC
{
    public class BookingPages_Wizard4 : MyElelment
    {
        
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div[2]/div/div/div[1]/div[2]/table[1]/tbody/tr/td/div/div[1]/div[1]")]
        private IWebElement sourceElement { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div[2]/div/div/div[1]/div[3]/table/tbody/tr[1]/td[1]")]
        private IWebElement destinationElement { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div[2]/div/div/div[1]/div[6]/div/button[1]")]
        private IWebElement btnProceed { get; set; }
        
        private void DoScrollTo(IWebDriver driver, By by)
        {
            System.Drawing.Point point = ((RemoteWebElement)driver.FindElement(by)).LocationOnScreenOnceScrolledIntoView;
        }

        public BookingPages_Wizard5 StepsForBookingWizard4(IWebDriver driver)
        {
            // need to wait for the page fully loaded
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.PollingInterval = TimeSpan.FromSeconds(2);
            wait.Until(drv => ((IJavaScriptExecutor)drv).ExecuteScript("return document.readyState").Equals("complete"));
            Actions action = new Actions(driver);
            action.DragAndDrop(sourceElement, destinationElement).Build().Perform();
            Thread.Sleep(3000);
            AimyClick(driver, btnProceed);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            return new BookingPages_Wizard5();
        }
    }
}
