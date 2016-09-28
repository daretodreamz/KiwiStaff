using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AimyTest
{
    public class MyElelment:MyChecking
    {
        public static readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        public static bool IsElementPresent(By by)
        {
            try
            {
                Utilities.Common.driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        /// <param name="timeoutInSeconds"></param>
        public void WaitForElementLoad(By by, int timeoutInSeconds)
        {
            // Create an “Explicit” wait to this driver:
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(Utilities.Common.driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
        }


        public static void AimySendKeys(IWebElement element, string sText)
        {
            WebDriverWait wait = new WebDriverWait(Utilities.Common.driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iShortWait));
            try

            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));


                if (element.Enabled)
                {
                    element.Clear();

                    //  log.Debug("AimySendKeys tried to sendkeys for " + i + " times");
                    // element.Click();

                    element.SendKeys(sText);
                }

            }
            catch (Exception ex)
            {
                log.Error("Element was not enable." + (element.Enabled).ToString());
                log.Error(ex.Message);
            }
        }



        public static void AimyClick(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Utilities.Common.driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iShortWait));
            try

            {
                 wait.Until(ExpectedConditions.ElementToBeClickable(element));
                // log.Debug("AimyClick for button [" + element.Text + "] try to click for " + i + " times");
                element.Click();
                return;
            }
            catch (Exception ex)
            {
                log.Error("Element was not enable." + (element).ToString());
                log.Error(ex.Message);
            }


        }
    }
}
