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

namespace AimyTest.Booking_Pages
{
    class BookingPages_Wizard1 : MyElelment
    {
        public BookingPages_Wizard1()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);
        }
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // select one of the children
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div/div[1]/div/div[2]/label[1]")]
        public IWebElement lblChild1 { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div/div[2]/div/div[2]/div/span")]
        public IWebElement lblProgrammesVenue { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[5]/div/div/div[2]/div[1]/div/div/a[1]")]
        public IWebElement lblSiteName { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[5]/div/div/div[3]/button[2]")]
        public IWebElement btnOK { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div/div[5]/button")]
        public IWebElement btnNext { get; set; }

        private void DoScrollTo(By by)
        {
            System.Drawing.Point point = ((RemoteWebElement)Common.driver.FindElement(by)).LocationOnScreenOnceScrolledIntoView;
        }

        private bool IsFirstChildSelected()
        {
            IWebElement element = null;
            try
            {
                WebDriverWait wait = new WebDriverWait(Common.driver, TimeSpan.FromSeconds(5));
                wait.PollingInterval = TimeSpan.FromSeconds(2);
                wait.Until(ExpectedConditions.ElementExists(By.XPath("html/body/div[3]/div[2]/div/div[1]/div/div[2]/label[1]/img")));
                element = Common.driver.FindElement(By.XPath("html/body/div[3]/div[2]/div/div[1]/div/div[2]/label[1]/img"));
                                                              
            }
            catch (Exception e)
            {
                if (element == null)
                {
                    log.Info("[INFO] the first child has NOT been selected!");
                    return false;
                }
            }
            if (!element.Displayed)
            {
                return false;
            }
            log.Info("[INFO] the first child has been selected!");
            return true;
        }

        private IWebElement FindAutomationSite()
        {
            //html/body/div[3]/div[5]/div/div/div[2]/div[1]/div/div/a
            IReadOnlyCollection<IWebElement> elements = null;
            try
            {
                IWait<IWebDriver> wait = new WebDriverWait(Common.driver, TimeSpan.FromSeconds(5));
                wait.PollingInterval = TimeSpan.FromSeconds(2);
                wait.Until(
                    ExpectedConditions.ElementExists(By.XPath("html/body/div[3]/div[5]/div/div/div[2]/div[1]/div/div/a")));
                elements = Common.driver.FindElements(By.XPath("html/body/div[3]/div[5]/div/div/div[2]/div[1]/div/div/a"));
                if (elements != null)
                {
                    foreach (var element in elements)
                    {
                        if (element.Text.Equals("AutomationTest"))
                        {
                            return element;
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public BookingPages_Wizard2 StepsForBookingWizard1()
        {
            if(!IsFirstChildSelected())
            {
                AimyClick(lblChild1);
            }
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(lblProgrammesVenue);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(FindAutomationSite());
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            DoScrollTo(By.XPath("html/body/div[3]/div[5]/div/div/div[3]/button[2]"));
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(btnOK);
            Thread.Sleep(2000);
            AimyClick(btnNext);
            return new BookingPages_Wizard2();
        }
    }
}
