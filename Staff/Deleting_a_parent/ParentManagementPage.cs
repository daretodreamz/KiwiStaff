﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AimyTest.Login;
using AimyTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AimyTest.Deleting_a_parent
{
    class ParentManagementPage : MyElelment
    {
        public ParentManagementPage()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);
        }

        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        static private string sURL;

       

        // 'Archive' item of DropDown List 
        [FindsBy(How = How.LinkText, Using = "ARCHIVE")]
        public IWebElement menuItemArchive { get; set; }

        // 'OK' button of Confirm Dialog 
        [FindsBy(How = How.Id, Using = "kiwi-confirm-yes")]
        public IWebElement buttonOK { get; set; }


        public bool TitleValidationExpectNagetive(IWebDriver driver, string TestName, string sTitle)
        {
            log.Info("Parents Mangement Validation Test Case: ");

            if (driver.Title == sTitle)
            {
                log.Info("[PASS] " + TestName);
                log.Info("driver.Title: " + "'" + driver.Title + "'" + " sTitle: " + "'" + sTitle + "'");
                return true;
            }
            log.Info("[FAIL] " + TestName);
            log.Info("We expect that " + "'" + driver.Title + "'" + " should be equal to " + "'" + sTitle + "'");
            return false;
        }


        public bool AchiveParent(IWebDriver driver, string ParentName, string ParentLoginEmail)
        {
            sURL = Utilities.GlobalVariable.sURL + "Parent/Management";
            driver.Navigate().GoToUrl(sURL);

            Utilities.Common.TitleValidation(Utilities.Common.driver, "AchiveParent",
                "Parent Management - aimy plus");


            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);


            IWebElement txtCategory = WebDriverExtensions.FindElement(driver, By.Id("category"), 2);

            AimySendKeys(txtCategory, ParentName);


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(500));
            wait.PollingInterval = TimeSpan.FromSeconds(2);
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("span.caret.split-dropdown-caret")));

            IReadOnlyCollection<IWebElement> items =
                driver.FindElements(By.CssSelector("span.caret.split-dropdown-caret"));

            foreach (var item in items)
            {

                item.Click();
                break;
            }

            AimyClick(menuItemArchive);
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            AimyClick(buttonOK);
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            var logout = new LogOut();
            logout.LogOutAimy(driver);
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            Common.driver.Navigate().GoToUrl(GlobalVariable.sURL);
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            var pgLogin = new LoginPage();
            pgLogin.LoginAimy(Common.driver, ParentLoginEmail, GlobalVariable.sloginPassword);
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            var ActualResutl = TitleValidationExpectNagetive(Utilities.Common.driver, "AchiveParent",
                "Login - AIMY");
            return ActualResutl;
            
        }

    }
}
