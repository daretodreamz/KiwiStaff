using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace AimyTest.Login_out
{
    public class LogOut : MyElelment
    {
        // User menu Dropdown
        [FindsBy(How = How.XPath, Using = "html/body/nav/div/div[2]/ul[2]/li[1]/ul/li[4]/a")]
        private IWebElement MnLogOut { get; set; }

         public void LogOutAimy(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            // User menu Dropdown with Hover mouse
            // Actions builder = new Actions(driver);
            wait.PollingInterval = TimeSpan.FromSeconds(2);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("html/body/nav/div/div[2]/ul[2]/li[1]/a[1]")));
            AimyClick(driver, driver.FindElement(By.LinkText("Hi Automation")));
            wait.Until(ExpectedConditions.ElementToBeClickable(MnLogOut));
            AimyClick(driver, MnLogOut);
         }
    }
}