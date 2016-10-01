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
    public class BookingPages_Wizard1 : MyElelment
    {
        
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // select one of the children
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div/div[1]/div/div[2]/label[1]")]
        private IWebElement lblChild1 { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div/div[2]/div/div[2]/div/span")]
        private IWebElement lblProgrammesVenue { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[5]/div/div/div[2]/div[1]/div/div/a[1]")]
        private IWebElement lblSiteName { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[5]/div/div/div[3]/button[2]")]
        private IWebElement btnOK { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div/div[5]/button")]
        private IWebElement btnNext { get; set; }

        private void DoScrollTo(IWebDriver driver, By by)
        {
            System.Drawing.Point point = ((RemoteWebElement)driver.FindElement(by)).LocationOnScreenOnceScrolledIntoView;
        }

        private bool IsFirstChildSelected(IWebDriver driver)
        {
            IWebElement element = null;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.PollingInterval = TimeSpan.FromSeconds(2);
                wait.Until(ExpectedConditions.ElementExists(By.XPath("html/body/div[3]/div[2]/div/div[1]/div/div[2]/label[1]/img")));
                element = driver.FindElement(By.XPath("html/body/div[3]/div[2]/div/div[1]/div/div[2]/label[1]/img"));
                                                              
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

        private IWebElement FindAutomationSite(IWebDriver driver)
        {
            //html/body/div[3]/div[5]/div/div/div[2]/div[1]/div/div/a
            IReadOnlyCollection<IWebElement> elements = null;
            try
            {
                IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.PollingInterval = TimeSpan.FromSeconds(2);
                wait.Until(
                    ExpectedConditions.ElementExists(By.XPath("html/body/div[3]/div[5]/div/div/div[2]/div[1]/div/div/a")));
                elements = driver.FindElements(By.XPath("html/body/div[3]/div[5]/div/div/div[2]/div[1]/div/div/a"));
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

        public BookingPages_Wizard2 StepsForBookingWizard1(IWebDriver driver)
        {
            if(!IsFirstChildSelected(driver))
            {
                AimyClick(driver, lblChild1);
            }
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, lblProgrammesVenue);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, FindAutomationSite(driver));
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            DoScrollTo(driver, By.XPath("html/body/div[3]/div[5]/div/div/div[3]/button[2]"));
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnOK);
            Thread.Sleep(2000);
            AimyClick(driver, btnNext);
            return new BookingPages_Wizard2();
        }
    }
}
