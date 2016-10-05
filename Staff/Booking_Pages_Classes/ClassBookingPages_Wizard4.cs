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

namespace AimyTest.Booking_Pages_Classes
{
    public class ClassBookingPages_Wizard4 : MyElelment
    {

        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div[2]/div[2]/div/div[2]/input")]
        private IWebElement btnBookThisClass { get; set; }

        
        private IWebElement SelectFirstClass(IWebDriver driver)
        {
           IReadOnlyCollection<IWebElement> lblClasses =
                driver.FindElements(By.XPath("html/body/div[3]/div[4]/div[2]/div[2]/div/div[1]/div/label"));
            if (lblClasses != null)
            {
                Thread.Sleep(2000);
                IWebElement  lblClass =
                driver.FindElements(By.XPath("html/body/div[3]/div[4]/div[2]/div[2]/div/div[1]/div/label"))[0];
                    return lblClass;
            }
                throw new Exception("[Exception] There is NO any classes available!");
        }

        private IWebElement SelectSecondClasses(IWebDriver driver)
        {
            IReadOnlyCollection<IWebElement> lblClasses =
                driver.FindElements(By.XPath("html/body/div[3]/div[4]/div[2]/div[2]/div/div[1]/div/label"));
            IWebElement tmp = null;
            if (lblClasses != null)           
            {
                foreach (var c in lblClasses)
                {
                    if (!c.GetAttribute("class").Contains("active"))
                    {
                        return c;
                    }
                    tmp = c;
                }
                return tmp;
            }
            throw new Exception("[Exception] There is NO any classes available!");
        }

    public void StepsForBookingWizard4(IWebDriver driver, bool selectOnlyOneClass= true)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            if (!selectOnlyOneClass)
            {
                IWebElement secondClass = SelectSecondClasses(driver);
                AimyClick(driver, secondClass);
            }
            else
            {
                AimyClick(driver, SelectFirstClass(driver));
            }

            Common.WaitBySleeping(GlobalVariable.iShortWait*2);
            AimyClick(driver, btnBookThisClass);
            Common.WaitBySleeping(GlobalVariable.iShortWait);

        }
    }
}
