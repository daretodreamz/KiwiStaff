using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Booking_Pages_BSC_ASC;
using AimyTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

namespace AimyTest.Booking_Pages_HolidayProgramme
{
    public class HolidayProgrammeBookingPages_Wizard2 : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // button for All week   
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div[1]/div/div[2]/table/thead/tr/th[2]/div/button")]
        private IWebElement btnAllWeek { get; set; }
        // drop down list for the programme
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div[1]/div/div[2]/table/thead/tr/th[2]/div/ul/li/a")]
        private IWebElement ddlProgramme { get; set; }
        // drop down list for the child
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div[1]/div/div[2]/table/thead/tr/th[2]/div/ul/li/ul/li/a")]
        private IWebElement ddlChild { get; set; }
        // Next Button
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div[1]/div/div[3]/button[2]")]
        private IWebElement btnNext { get; set; }

        private void DoScrollTo(IWebDriver driver, By by)
        {
            System.Drawing.Point point = ((RemoteWebElement)driver.FindElement(by)).LocationOnScreenOnceScrolledIntoView;
        }

        public void StepsForBookingWizard2(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnAllWeek);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            AimyClick(driver, ddlProgramme);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            AimyClick(driver, ddlChild);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            DoScrollTo(driver, By.XPath("html/body/div[3]/div[4]/div/div[1]/div/div[3]/button[2]"));
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            AimyClick(driver, btnNext);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
        }
    }
}
