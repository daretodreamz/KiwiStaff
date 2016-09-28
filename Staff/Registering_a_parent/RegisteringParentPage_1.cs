using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace AimyTest.Registering_a_parent
{
    public class RegisteringParentPage_1 : MyElelment
    {
        public RegisteringParentPage_1()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);

        }

        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();


        private IJavaScriptExecutor executor = Utilities.Common.driver as IJavaScriptExecutor;

        static private string sURL;

        // Textbox Login Email
        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement txtLoginEmail { get; set; }

        // Textbox Contact Email 
        [FindsBy(How = How.Id, Using = "Email1")]
        public IWebElement txtContactEmail { get; set; }

        // Textbox FirstName
        [FindsBy(How = How.Id, Using = "FirstName1")]
        public IWebElement txtFirstName { get; set; }

        // Textbox LastName
        [FindsBy(How = How.Id, Using = "LastName1")]
        public IWebElement txtLastName { get; set; }

        // Textbox Password
        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement txtPassword { get; set; }

        // Textbox PasswordConfirm
        [FindsBy(How = How.Id, Using = "PasswordConfirm")]
        public IWebElement txtPasswordConfirm { get; set; }

        // Checkbox Terms and Conditions Agreement
        [FindsBy(How = How.Id, Using = "termsCondsCheckBox")]
        public IWebElement chkTermsConds { get; set; }

        // Button Submit
        [FindsBy(How = How.XPath, Using = "//*[@id='submitButton']")]
        public IWebElement btnsubmitButton { get; set; }

        private int FillInfo(IWebDriver driver
                             , string email
                             , string contactEmail
                             , string FirstName
                             , string LastName
                             , string password)
        {
            WebDriverWait wait = new WebDriverWait(Utilities.Common.driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iShortWait));
            try
            {

                AimySendKeys(txtLoginEmail, email);
                AimySendKeys(txtContactEmail, email);
                AimySendKeys(txtFirstName, FirstName);
                AimySendKeys(txtLastName, LastName);
                AimySendKeys(txtPassword, password);
                AimySendKeys(txtPasswordConfirm, password);
                AimyClick(chkTermsConds);

                Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
                Utilities.Common.TakeScreenShot("TC_CRE_PARENT_01_1_FillInformation");
                log.Debug("TC_CRE_PARENT_01_1_FillInformation: Enter information to create a new parent");

                AimyClick(btnsubmitButton);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                log.Error(e.StackTrace);

                Utilities.Common.TakeScreenShot("TC_CRE_PARENT_01_1_FillInformation FAIL");
                log.Error("[FAIL] TC_CRE_PARENT_01_1_FillInformation: Enter information to create a new parent.");

                return 1;
            }
            return 0;
        }

        /// <summary>
        /// tese case TC_CRE_PARENT_01_1_FillInformation by Admin "Parent/RegisterFromAdmin" URL
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="email"></param>
        /// <param name="contactEmail"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public RegisteringParentPage_30_PersonalDetailPage TC_CRE_PARENT_01_1_FillInformation(IWebDriver driver
                            , out string email
                             , string contactEmail
                             , string FirstName
                             , string LastName
                             , string password)
        {


            email = string.Format("{0}", Guid.NewGuid());
            email = email.Substring(0, 5) + "@delete.auto.com"; 

            sURL = Utilities.GlobalVariable.sURL + "Parent/RegisterFromAdmin";
            driver.Navigate().GoToUrl(sURL);

            Utilities.Common.TitleValidation(driver, " Create Parent by Admin", "Register - aimy plus");
            TestDescription = "Filling Data";

            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);

            FillInfo(driver, email, contactEmail, FirstName, LastName, password);

            log.Debug("Parent info entered: Login email: " + email
                               + " contactEmail: " + contactEmail
                               + " FirstName: " + FirstName
                               + " LastName: " + LastName
                               + " Parent ID:" + Utilities.Common.GetParentID());

            return new RegisteringParentPage_30_PersonalDetailPage();
        }
        public void TC_CRE_PARENT_UI_01_1_Data_Required_Validation(IWebDriver driver, string TCDesc)
        {
            AimyClick(chkTermsConds);
            AimyClick(btnsubmitButton);

            // XPath of Web element 
            // verify for the error of empty email username
            script = "return $('span[for= Username]').text();";
            ActualText = (string)executor.ExecuteScript(script);
            expectedText = Utilities.ExcelLib.ReadData(2, "ErrMsg");
            Utilities.Common.PrintResult(ActualText, expectedText, TCDesc, "Empty email login", false, ActualText.Equals(expectedText));

            // verify for the error of empty contact email
            script = "return $('span[for= Email1]').text();";
            ActualText = (string)executor.ExecuteScript(script);
            expectedText = Utilities.ExcelLib.ReadData(3, "ErrMsg");
            Utilities.Common.PrintResult(ActualText, expectedText, TCDesc, "Empty contact email", false, ActualText.Equals(expectedText));


            // verify for the error of empty FirstName
            script = "return $('span[for= FirstName1]').text();";
            ActualText = (string)executor.ExecuteScript(script);
            expectedText = Utilities.ExcelLib.ReadData(4, "ErrMsg");
            Utilities.Common.PrintResult(ActualText, expectedText, TCDesc, "Empty FirstName", false, ActualText.Equals(expectedText));


            // verify for the error of empty LastName1
            script = "return $('span[for= LastName1]').text();";
            ActualText = (string)executor.ExecuteScript(script);
            expectedText = Utilities.ExcelLib.ReadData(5, "ErrMsg");
            Utilities.Common.PrintResult(ActualText, expectedText, TCDesc, "Empty LastName1", false, ActualText.Equals(expectedText));

            // verify for the error of empty Password
            script = "return $('span[for= Password]').text();";
            ActualText = (string)executor.ExecuteScript(script);
            expectedText = Utilities.ExcelLib.ReadData(6, "ErrMsg");
            Utilities.Common.PrintResult(ActualText, expectedText, TCDesc, "Empty Password", false, ActualText.Equals(expectedText));

            // verify for the error of empty PasswordConfirm
            script = "return $('span[for= PasswordConfirm]').text();";
            ActualText = (string)executor.ExecuteScript(script);
            expectedText = Utilities.ExcelLib.ReadData(7, "ErrMsg");
            Utilities.Common.PrintResult(ActualText, expectedText, TCDesc, "Empty PasswordConfirm", false, ActualText.Equals(expectedText));

        }

        public int ErrormsgValidation(IWebDriver driver, string TCDesc)
        {
            TestDescription = "ErrormsgValidation ";
            WebDriverWait wait = new WebDriverWait(Utilities.Common.driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iShortWait));

            wait.Until(ExpectedConditions.ElementToBeClickable(btnsubmitButton));


            // verify for the error of Password does not match
            if (txtPasswordConfirm.Enabled && txtPassword.Enabled)
            {
                txtPassword.Clear();
                txtPassword.SendKeys("abc21542");
                txtPassword.SendKeys(Keys.Tab);
                txtPasswordConfirm.Clear();
                txtPasswordConfirm.SendKeys("abciuhbddcx");
                txtPassword.SendKeys(Keys.Tab);

                // verify for the error of  Password does not match
                script = "return $('span[for= PasswordConfirm]').text();";
                ActualText = (string)executor.ExecuteScript(script);
                expectedText = Utilities.ExcelLib.ReadData(9, "ErrMsg");
                Utilities.Common.PrintResult(ActualText, expectedText, TCDesc, "Confirm Password  Password does not match", false, ActualText.Equals(expectedText));

            }
            else
            {
                log.Error("txtPasswordConfirm.Enabled" + (txtPasswordConfirm.Enabled).ToString());
                Utilities.Common.TakeScreenShot(TestDescription + " txtPasswordConfirm.Enabled_Fail");

                return 1;
            }



            if (txtLoginEmail.Enabled)
            {
                txtLoginEmail.Clear();
                txtLoginEmail.SendKeys("abc");
                txtLoginEmail.SendKeys(Keys.Tab);

                // verify for the error of invalid email
                script = "return $('span[for= Username]').text()";
                ActualText = (string)executor.ExecuteScript(script);
                expectedText = Utilities.ExcelLib.ReadData(10, "ErrMsg");
                Utilities.Common.PrintResult(ActualText, expectedText, TCDesc, "Invalid email", false, ActualText.Equals(expectedText));
                wait.Until(ExpectedConditions.ElementToBeClickable(txtLoginEmail));

                // verify for the error of existed  email	
                //abc @test.com

                txtLoginEmail.Clear();
                txtLoginEmail.SendKeys("abc@test.com");
                txtLoginEmail.SendKeys(Keys.Tab);

                script = "return $('span[for= Username]').text();";
                ActualText = (string)executor.ExecuteScript(script);
                expectedText = Utilities.ExcelLib.ReadData(13, "ErrMsg");
                Utilities.Common.PrintResult(ActualText, expectedText, TCDesc, "Invalid email", false, ActualText.Equals(expectedText));


            }
            else
            {
                log.Error("txtLoginEmail.Enabled" + (txtLoginEmail.Enabled).ToString());
                Utilities.Common.TakeScreenShot(TestDescription + " txtLoginEmail.Enabled_Fail");

                return 1;
            }

            // verify for the error of invalid contact email

            if (txtContactEmail.Enabled)
            {
                txtContactEmail.Clear();
                txtContactEmail.SendKeys("abc");
                txtContactEmail.SendKeys(Keys.Tab);

                // verify for the error of invalid contact email
                script = "return $('span[for= Email1]').text();";
                ActualText = (string)executor.ExecuteScript(script);
                expectedText = Utilities.ExcelLib.ReadData(11, "ErrMsg");
                Utilities.Common.PrintResult(ActualText, expectedText, TCDesc, "Invalid contact email", false, ActualText.Equals(expectedText));

            }
            else
            {
                log.Error("txtContactEmail.Enabled" + (txtContactEmail.Enabled).ToString());
                Utilities.Common.TakeScreenShot(TestDescription + " txtContactEmail.Enabled_Fail");

                return 1;
            }

            // verify for the error of Lenght Password
            if (txtPassword.Enabled)
            {
                txtPassword.Clear();
                txtPassword.SendKeys("abc");
                txtPassword.SendKeys(Keys.Tab);

                // verify for the error of password lenght
                script = "return $('span[for= Password]').text();";
                ActualText = (string)executor.ExecuteScript(script);
                expectedText = Utilities.ExcelLib.ReadData(8, "ErrMsg");
                Utilities.Common.PrintResult(ActualText, expectedText, TCDesc, "Password with 8 chars", false, ActualText.Equals(expectedText));

            }
            else
            {
                log.Error("txtPassword.Enabled" + (txtPassword.Enabled).ToString());
                Utilities.Common.TakeScreenShot(TestDescription + " txtPassword.Enabled_Fail");

                return 1;
            }


            // verify for the error of Password does not match
            if (txtPasswordConfirm.Enabled && txtPassword.Enabled)
            {
                txtPassword.Clear();
                txtPassword.SendKeys("abc21542");
                txtPassword.SendKeys(Keys.Tab);
                txtPasswordConfirm.Clear();
                txtPasswordConfirm.SendKeys("abciuhbddcx");
                txtPassword.SendKeys(Keys.Tab);

                // verify for the error of  Password does not match
                script = "return $('span[for= PasswordConfirm]').text();";
                ActualText = (string)executor.ExecuteScript(script);
                expectedText = Utilities.ExcelLib.ReadData(9, "ErrMsg");
                Utilities.Common.PrintResult(ActualText, expectedText, TCDesc, "'Confirm Password  Password does not match", false, ActualText.Equals(expectedText));

            }
            else
            {
                log.Error("txtPasswordConfirm.Enabled" + (txtPasswordConfirm.Enabled).ToString());
                Utilities.Common.TakeScreenShot(TestDescription + " txtPasswordConfirm.Enabled_Fail");

                return 1;
            }

            return 0;
        }
    }
}
