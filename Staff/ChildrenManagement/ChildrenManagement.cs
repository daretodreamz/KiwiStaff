using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AimyTest.Children_Management
{
    public class ChildrenManagement : MyElelment
    {

        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        static private string sURL;

        // 'Archive' item of DropDown List 
        [FindsBy(How = How.LinkText, Using = "ARCHIVE")]
        private IWebElement menuItemArchive { get; set; }

        // 'OK' button of Confirm Dialog 
        [FindsBy(How = How.Id, Using = "archive-exclude-parent")]
        private IWebElement buttonNO { get; set; }

        private bool ValidationChildAchive(IWebDriver driver, string TestName)
        {
            log.Info("Children Management Validation Test Case: ");
            IReadOnlyCollection<IWebElement> elements = null;
            try
            {
                elements = WebDriverExtensions.FindElements(driver,
                    By.LinkText("Profile"),
                    10);
            }
            catch (Exception e)
            {
                if (elements == null)
                {
                    log.Info("[PASS] " + TestName);
                    log.Info("We expect that there should NO 'Profile' link for this parent.");
                    return true;
                }
            }
            log.Info("[FAIL] " + TestName);
            log.Info("There is 'Profile' link for this parent!");
            return false;
        }

        public bool AchiveChildren(IWebDriver driver, string ChildName)
        {
            sURL = GlobalVariable.sURL + "Parent/ChildManagement";
            driver.Navigate().GoToUrl(sURL);

            Common.TitleValidation(driver, "AchiveChildren",
                "Child Management - aimy plus");


            Common.WaitBySleeping(GlobalVariable.iShortWait);

            IWebElement txtCategory = WebDriverExtensions.FindElement(driver, By.Id("category"), 2);

            AimySendKeys(driver, txtCategory, ChildName);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.PollingInterval = TimeSpan.FromSeconds(2);
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("span.caret.split-dropdown-caret")));

            IReadOnlyCollection<IWebElement> items =
                driver.FindElements(By.CssSelector("span.caret.split-dropdown-caret"));

            foreach (var item in items)
            {
                item.Click();
                break;
            }

            AimyClick(driver, menuItemArchive);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, buttonNO);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            driver.Navigate().GoToUrl(sURL);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimySendKeys(driver, WebDriverExtensions.FindElement(driver, By.Id("category"), 2), ChildName);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            bool actulResult = ValidationChildAchive(driver, "AchiveChildren");
            return actulResult;
        }
    }
}