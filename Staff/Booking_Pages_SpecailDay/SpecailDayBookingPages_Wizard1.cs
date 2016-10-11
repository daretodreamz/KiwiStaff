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

namespace AimyTest.Booking_Pages_SpecialDay
{
    public class SpecialDayBookingPages_Wizard1 : MyElelment
    {

        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // select one of the children      
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div/div[1]/div/div[2]/label[1]")]
        private IWebElement lblChild1 { get; set; }

        // select one of the children
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div/div[1]/div/div[2]/label[2]")]
        private IWebElement lblChild2 { get; set; }

        //[FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div/div[2]/div/div[2]/div/span")]
        //private IWebElement lblProgrammesVenue { get; set; }

        //[FindsBy(How = How.XPath, Using = "html/body/div[3]/div[5]/div/div/div[2]/div[1]/div/div/a[1]")]
        //private IWebElement lblSiteName { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div/div[3]/div/div[2]/label[3]")]
        private IWebElement lblBookingType { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div/div[5]/button")]
        private IWebElement btnNext { get; set; }

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
                    log.Info("[INFO] there is NO element existing!");
                    return false;
                }
            }
            if (!element.Displayed)
            {
                log.Info("[INFO] the first child has NOT been selected!");
                return false;
            }
            log.Info("[INFO] the first child has been selected!");
            return true;
        }

        public void StepsForBookingWizard1(IWebDriver driver, bool needSecondChild = false)
        {
            if (!IsFirstChildSelected(driver))
            {
                AimyClick(driver, lblChild1);
                if (needSecondChild)
                {
                    IReadOnlyCollection<IWebElement> elems = WebDriverExtensions.FindElements(driver, By.XPath("html/body/div[3]/div[2]/div/div[1]/div/div[2]/label"), 2);
                    if(elems.Count>=2)
                        AimyClick(driver, lblChild2);
                    else throw new Exception("The second child is NOT available!!");
                }
            }
            Common.WaitBySleeping(GlobalVariable.iShortWait * 2);
            AimyClick(driver, lblBookingType);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 2);
            AimyClick(driver, btnNext);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
        }
    }
}
