using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace AimyTest.Login
{
    public class LogOut : MyElelment
    {

        public LogOut()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);

        }
      
        // User menu Dropdown
        [FindsBy(How = How.XPath, Using = ".//*[@id='menuitem-login']/ul/li[4]/a")]
        public IWebElement MnLogOut { get; set; }

         public void LogOutAimy(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(Utilities.Common.driver, TimeSpan.FromSeconds(15));
            // User menu Dropdown with Hover mouse
            // Actions builder = new Actions(driver);
            wait.PollingInterval = TimeSpan.FromSeconds(2);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("html/body/nav/div/div[2]/ul[2]/li[1]/a[1]")));
            AimyClick(driver.FindElement(By.LinkText("Hi Automation")));
            wait.Until(ExpectedConditions.ElementToBeClickable(MnLogOut));
            AimyClick(MnLogOut);
         }
    }
}