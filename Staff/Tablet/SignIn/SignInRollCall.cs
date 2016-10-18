using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AimyTest.Tablet.SignIn
{
    public class SignInRollCall : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // Click on Green Tick
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[3]/div[2]/ul/li[1]/div[1]/div[2]/div/a[1]/img")]
        private IWebElement btnGreenTick { get; set; }
        // Click on Red Tick
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[3]/div[2]/ul/li[1]/div[1]/div[2]/div/a[2]/img")]
        private IWebElement btnRedTick { get; set; }

        // Reason Not Pick up              
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[17]/div/div/ul/li[6]/a")]
        private IWebElement itemOtherNotPickup { get; set; }
        //otherReasonTextarea
        [FindsBy(How = How.Id, Using = "otherReasonTextarea")]
        private IWebElement otherReasonTextarea { get; set; }
        //saveOtherReason
        [FindsBy(How = How.Id, Using = "saveOtherReason")]
        private IWebElement saveOtherReason { get; set; }


        private int PositionChild(IWebDriver driver, string childName)
        {
            var elements = driver.FindElements(By.XPath("html/body/div[4]/div[3]/div[2]/ul/li"));
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
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            int i = PositionChild(driver, whichChild);
            if (i == -1) throw new Exception("There is NOT any items available, Please check!");
            AimyClick(driver, driver.FindElement(By.XPath("html/body/div[4]/div[3]/div[2]/ul/li[" + i + "]/div[1]/div[2]/div/a[1]/img")));
            return true;
        }
        public bool ClickOnRedTick(IWebDriver driver, string whichChild)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            int i = PositionChild(driver, whichChild);
            if (i == -1) throw new Exception("There is NOT any items available, Please check!");
            AimyClick(driver, driver.FindElement(By.XPath("html/body/div[4]/div[3]/div[2]/ul/li[" + i + "]/div[1]/div[2]/div/a[2]/img")));
            return true;
        }
        public bool ChooseOtherReason(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, itemOtherNotPickup);
            AimySendKeys(driver, otherReasonTextarea, "Other");
            AimyClick(driver, saveOtherReason);
            return true;
        }
    }
}
