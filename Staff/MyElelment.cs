using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AimyTest
{
    public class MyElelment : MyChecking
    {
        public static readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        public static bool IsElementPresent(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        /// <param name="timeoutInSeconds"></param>
        public void WaitForElementLoad(IWebDriver driver, By by, int timeoutInSeconds)
        {
            // Create an “Explicit” wait to this driver:
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
        }


        public static void AimySendKeys(IWebDriver driver, IWebElement element, string sText)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iShortWait));
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



        public static void AimyClick(IWebDriver driver, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iShortWait));
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
