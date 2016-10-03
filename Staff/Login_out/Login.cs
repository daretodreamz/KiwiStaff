using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using AimyTest.Utilities;
using NUnit.Framework;

namespace AimyTest.Login_out

{
    public class Login : MyElelment
    {
        string script, textYouWant, expectedText;

        // User name textbox
        [FindsBy(How = How.Id, Using = "inputUserName")]
        private IWebElement txtUserName { get; set; }

        //Password textbox
        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement txtPassword { get; set; }

        // Login button
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/form/div[4]/div[5]/input")]
        private IWebElement btnLogin { get; set; }

        // Login button
        [FindsBy(How = How.XPath, Using = "html/body/nav/div/div[2]/ul[1]/li[1]/a")]
        private IWebElement MenuDaskBoard { get; set; }


        // Login Method
        public void LoginAimy(IWebDriver driver, string userName, string password)
        {
            Utilities.Common.TitleValidation(driver, "Title of Login Page Validation", "Login - AIMY");

            EnterData(driver, userName, password);

            driver.Manage().Window.Maximize();

            // [Hana] May 12 2016
            // Staff doesn't have dash board, need to find another way to check here
            //WebDriverWait wait = new WebDriverWait(Utilities.Common.driver, TimeSpan.FromSeconds(5));

            //wait.Until(ExpectedConditions.TextToBePresentInElement(MenuDaskBoard, "Dashboard"));


        }

        public void ChangingWorkingSite(IWebDriver driver, string sSite)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Actions action = new Actions(driver);
            // selecting for a working site
            // Open to dialog to enter the site

            AimyClick(driver, driver.FindElement(By.XPath("/html/body/nav/div/div[2]/ul[2]/li[2]/span")));

            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iMediumWait);

            IWebElement a;
            a = driver.FindElement(By.XPath("//*[@id='myModalSiteSearch']/div/div/div/div/span/span/input"));
            action.MoveToElement(a);
            action.Perform();

            a.SendKeys(sSite);

            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iMediumWait);

            a.SendKeys(Keys.Up);
            // log.Debug("try to  give key up to select a site to switch to");

            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iMediumWait);
            a.SendKeys(Keys.Enter);

            //log.Debug("try to give Enter to select a site to switch to");
            //$("#currentSite span").text()

            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iMediumWait);

            var executor = driver as IJavaScriptExecutor;
            string currentSite = (string) executor.ExecuteScript("return $('#currentSite span').text(); ");
            currentSite = currentSite.TrimStart();

            log.Debug("Current site " + currentSite);

            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iMediumWait);



        }

        public int EnterData(IWebDriver driver, string userName, string password)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iShortWait));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(btnLogin));

                AimySendKeys(driver, txtUserName, userName);
                AimySendKeys(driver, txtPassword, password);

                AimyClick(driver, btnLogin);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return 1;
            }


            return 0;
        }

        //INVALID_LOGIN_001 Empty UserName_Password
        public void TC_INVALID_LOGIN_001(IWebDriver driver, string userName, string password, string TestDescription)
        {
            EnterData(driver, userName, password);

            script = "return $('span[for= UserName]').text();";

            var executor = driver as IJavaScriptExecutor;
            textYouWant = (string) executor.ExecuteScript(script);
            expectedText = Utilities.ExcelLib.ReadData(2, "ErrMsg");

            Utilities.Common.PrintResult(driver, textYouWant, expectedText, TestDescription, "", true,
                textYouWant.Equals(expectedText));

            script = "return $('span[for= Password]').text();";
            textYouWant = (string) executor.ExecuteScript(script);
            expectedText = Utilities.ExcelLib.ReadData(3, "ErrMsg");

            Utilities.Common.PrintResult(driver, textYouWant, expectedText, TestDescription, "", true,
                textYouWant.Equals(expectedText));


        }

        //INVALID_LOGIN_003 Empty Password
        public void TC_INVALID_LOGIN_003(IWebDriver driver, string userName, string password, string TestDescription)
        {
            EnterData(driver, userName, password);
            // verify for the message required password
            script = "return $('span[for= UserName]').text();";

            var executor = driver as IJavaScriptExecutor;
            textYouWant = (string) executor.ExecuteScript(script);
            expectedText = Utilities.ExcelLib.ReadData(2, "ErrMsg");

            Utilities.Common.PrintResult(driver, textYouWant, expectedText, TestDescription, "", true,
                textYouWant.Equals(expectedText));

        }

        //INVALID_LOGIN_002 Empty UserName
        public void TC_INVALID_LOGIN_002(IWebDriver driver, string userName, string password, string TestDescription)
        {
            EnterData(driver, userName, password);
            script = "return  $('span[for= Password]').text();";

            var executor = driver as IJavaScriptExecutor;
            textYouWant = (string) executor.ExecuteScript(script);
            expectedText = Utilities.ExcelLib.ReadData(3, "ErrMsg");

            Utilities.Common.PrintResult(driver, textYouWant, expectedText, TestDescription, "", true,
                textYouWant.Equals(expectedText));

        }

        //INVALID_LOGIN_004 Wrong UserName_Password
        public void TC_INVALID_LOGIN_004(IWebDriver driver, string userName, string password, string TestDescription)
        {
            EnterData(driver, userName, password);

            // verify for the message for failure login
            // Text displayed with CR => failure to comparing
            script = "return $('.validation-summary-errors').text();";

            var executor = driver as IJavaScriptExecutor;
            textYouWant = (string) executor.ExecuteScript(script);
            expectedText = Utilities.ExcelLib.ReadData(4, "ErrMsg");

            Utilities.Common.PrintResult(driver, textYouWant, expectedText, TestDescription, "", true,
                textYouWant.Contains(expectedText));

        }

        public Int16 FillDataAndCheck(IWebDriver driver, string userName, string password, string TestDescription)
        {
            //Utilities.Common.TitleValidation(Utilities.Common.driver, "Title of Login Page Validation", "Login - AIMY");

            EnterData(driver, userName, password);

            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
            {
                TC_INVALID_LOGIN_001(driver, userName, password, TestDescription);
            }
            else // having username OR password
            {

                if (string.IsNullOrEmpty(userName))
                {
                    TC_INVALID_LOGIN_002(driver, userName, password, TestDescription);
                }
                else if (string.IsNullOrEmpty(password))
                {
                    TC_INVALID_LOGIN_003(driver, userName, password, TestDescription);
                    // verify for the message
                }
                else // both of them are not null

                {
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(200));
                    var a = Utilities.Common.TitleValidation(driver, "Title of Dashboard Page Validation",
                        "Dashboard - aimy plus");
                    if (a == 0) // login sucess
                    {
                        Utilities.Common.TakeScreenShot(driver, TestDescription);
                        log.Info(TestDescription + " Login successful, Username/Pass: " + userName + " , " + password);
                    }
                    else

                        TC_INVALID_LOGIN_004(driver, userName, password, TestDescription);
                }
            }
            return 0; // succeed
        }

        public bool LockUserWith10TimesInvalidPasswordInput(IWebDriver driver, string userName, string password,
            string TestDescription)
        {
            var executor = driver as IJavaScriptExecutor;
            script = "return $('.validation-summary-errors').text();";
            int result;
            for (int i = 1; i <= 9; i++)
            {

                result = EnterData(driver, userName, password);
                Assert.AreEqual(0, result);
                
                expectedText = "The Email or Password provided is incorrect.";
                IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.PollingInterval = TimeSpan.FromSeconds(2);
                wait.Until(drv => ((IJavaScriptExecutor)drv).ExecuteScript("return document.readyState").Equals("complete"));
                textYouWant = (string) executor.ExecuteScript(script);
                Assert.AreEqual(true, textYouWant.Contains(expectedText));
            }

            // verify for the message for failure login
            // Text displayed with CR => failure to comparing
            result = EnterData(driver, userName, password);
            Assert.AreEqual(0, result);
            textYouWant = (string)executor.ExecuteScript(script);
            expectedText = "Account has been disabled, please contact support.";
            return textYouWant.Contains(expectedText);
        }
    }
}