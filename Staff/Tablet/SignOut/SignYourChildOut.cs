using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AimyTest.Tablet.SignOut
{
    public class SignYourChildOut : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // Click on Green Tick              
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[3]/div/ul/li/div[1]/div[2]/div/a/img")]
        private IWebElement btnGreenTick { get; set; }

        // No Records            
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[3]/div[1]/h3")]
        private IWebElement checkPoint { get; set; }

        private int PositionChild(IWebDriver driver, string childName)
        {
            var elements = driver.FindElements(By.XPath("html/body/div[4]/div[3]/div/ul/li/div[1]/div[1]/div[2]/a/h1"));
            if (elements.Count > 0)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    if (elements.ElementAt(i).Text.Contains(childName))
                    {
                        return i + 1;
                    }
                }
            }
            return -1;
        }

        public bool ClickOnGreenTick(IWebDriver driver, string whichChild)
        {
            IWebElement element = null;
            try
            {
                element = driver.FindElement(By.XPath("html/body/div[4]/div[3]/div[1]/h3"));

            }
            catch (NoSuchElementException) {
                Common.WaitBySleeping(GlobalVariable.iShortWait);
                int i = PositionChild(driver, whichChild);
                if (i == -1) throw new Exception("There is NOT any items available, Please check!");
                AimyClick(driver, driver.FindElement(By.XPath("html/body/div[4]/div[3]/div/ul/li[" + i + "]/div[1]/div[2]/div/a/img")));
                return true;
            }
                       
            return false;
        }

        public bool CheckNoRecord(IWebDriver driver)
        {
            return checkPoint.Text.Equals("No Record For Today");
        }
    }
}
