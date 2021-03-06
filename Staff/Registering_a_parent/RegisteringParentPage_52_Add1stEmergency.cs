﻿
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AimyTest.Registering_a_parent
{
    public class RegisteringParentPage_52_Add1stEmergency: MyElelment
    {
        private IJavaScriptExecutor executor = Utilities.Common.driver as IJavaScriptExecutor;

        public RegisteringParentPage_52_Add1stEmergency()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);

        }
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // Login button
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/form/div/div[1]/div[2]/a")]
        public IWebElement btnSelectPhoto { get; set; }

        // Textbox FirstName
        [FindsBy(How = How.Id, Using = "FirstNameEm1")]
        private IWebElement txtFirstName { get; set; }

        // Textbox LastName
        [FindsBy(How = How.Id, Using = "LastNameEm1")]
        private IWebElement txtLastName { get; set; }

        // Textbox Relationship
        [FindsBy(How = How.Id, Using = "RelationEm1")]
        private IWebElement txtRelationship { get; set; }

        // Textbox Mobile
        public void txtMobile_js(string Mobile)
        {
            executor.ExecuteScript("$('#MobileEm1').val('" + Mobile + "')");

        }

        // Textbox HomePhone
        public void txtHomePhone_js(string Mobile)
        {
            executor.ExecuteScript("$('#OfficeEm1').val('" + Mobile + "')");
        }

        // Textbox Work Phone
        public void txtWorkPhone_js(string Mobile)
        {
            executor.ExecuteScript("$('#LandlineEm1').val('" + Mobile + "')");
        }


        // Button Submit
        [FindsBy(How = How.Id, Using = "submitButton1")]
        private IWebElement btnsubmitButton { get; set; }

        // Uploading a Photo


        public void TC_CRE_PARENT_03_Fill_1_EmergencyContact(IWebDriver driver
                            , string FirstName
                            , string LastName
                            , string Relationship
                            , string Mobile
                            , string HomePhone
                            , string WorkPhone)
        {
            Utilities.Common.TitleValidation(Utilities.Common.driver, " Create 1st Emergency Contact Profile by Admin", "Emergency Contact - aimy plus");

            FillInfo(driver, FirstName, LastName, Relationship, Mobile, HomePhone, WorkPhone);
         
            

            log.Debug(" Submitted the 1st emergency contact: FirstName: " + FirstName
                              + " LastName: " + LastName
                   + " Relationship to the child: " + Relationship
                  + " Mobile: " + Mobile
                  + " HomePhone: " + HomePhone
                  + " WorkPhone: " + WorkPhone);

            script = "return document.getElementsByClassName('col-sm-6')[1].innerText;";

            if (Verify_ParentName(script, "Name : " + FirstName.Trim()) && (Verify_ParentName(script, LastName.Trim())))
            {
                log.Info("[PASS] CRE_PARENT_03 Registering new emergency contacts");
                Utilities.Common.TakeScreenShot("CRE_PARENT_03 Registering new emergency contacts");

            }
            else // wrong text display
            {
                log.Error("[FAIL] CRE_PARENT_03 Registering new emergency contacts-wrong text displayed");
                Utilities.Common.TakeScreenShot("FAIL- CRE_PARENT_03 Registering new emergency contacts");

            }

            Utilities.Common.TitleValidation(Utilities.Common.driver, " Back to Parent Profile by Admin", "Profile - aimy plus");

            // return new RegisteringParentPage5_ParentProfile();

        }

        public int FillInfo(IWebDriver driver
                            , string FirstName
                            , string LastName
                            , string Relationship
                            , string Mobile
                            , string HomePhone
                            , string WorkPhone)
        {
            WebDriverWait wait = new WebDriverWait(Utilities.Common.driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iShortWait));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(btnsubmitButton));
                AimySendKeys(txtFirstName, FirstName);
                AimySendKeys(txtLastName, LastName);
                AimySendKeys(txtRelationship, Relationship);

                txtMobile_js(Mobile);
                txtHomePhone_js(HomePhone);
                txtWorkPhone_js(WorkPhone);
                Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
                Utilities.Common.TakeScreenShot("1_EmergencyContact");
                log.Debug("[Pass] TC_CRE_PARENT_03_Fill_1_EmergencyContact");

                AimyClick(btnsubmitButton);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                log.Error(e.StackTrace);

                Utilities.Common.TakeScreenShot("1_EmergencyContact FAIL");
                log.Error("ERROR- Fill_1_EmergencyContact");
                return 1;
            }
            return 0;
        }

    }
}
