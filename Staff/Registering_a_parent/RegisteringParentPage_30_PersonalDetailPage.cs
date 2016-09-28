using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Globalization;

namespace AimyTest.Registering_a_parent
{
    public class RegisteringParentPage_30_PersonalDetailPage : MyElelment
    {
        private IJavaScriptExecutor executor = Utilities.Common.driver as IJavaScriptExecutor;
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();


        public RegisteringParentPage_30_PersonalDetailPage()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);

        }


        [FindsBy(How = How.Id, Using = "DateOfBirth")]
        public IWebElement txtDateOfBirth { get; set; }

        public void txtMobile1_js(string Mobile)
        {
            executor.ExecuteScript("$('#Mobile1').val('" + Mobile + "')");

        }
        public void txtLandline1_js(string Mobile)
        {
            executor.ExecuteScript("$('#Landline1').val('" + Mobile + "')");

        }
        public void txtOffice1_js(string Mobile)
        {
            executor.ExecuteScript("$('#Office1').val('" + Mobile + "')");

        }
        public void txtOfficeExtension_js(string Mobile)
        {
            executor.ExecuteScript("$('#OfficeExtension').val('" + Mobile + "')");

        }
        [FindsBy(How = How.Id, Using = "StreetNumber")]
        public IWebElement txtStreetNumber { get; set; }

        [FindsBy(How = How.Id, Using = "Address")]
        public IWebElement txtAddress { get; set; }

        [FindsBy(How = How.Id, Using = "Suburb")]
        public IWebElement txtSuburb { get; set; }

        [FindsBy(How = How.Id, Using = "City")]
        public IWebElement txtCity { get; set; }

        public void txtPostCode_js(string Postcode)

        {
            executor.ExecuteScript("$('#Postcode').val('" + Postcode + "')");
        }

        [FindsBy(How = How.Id, Using = "Country")]
        public IWebElement txtCountry { get; set; }

        // did not work, fill billing address manually
        public void chksameAddressCheckBox_js()
        {
            executor.ExecuteScript("document.getElementById('sameAddressCheckBox').setAttribute('checked','True')");
            executor.ExecuteScript("document.getElementById('sameAddressCheckBox').click()");

        }


        public void LstHowHear_js(string HowHear)
        {
            executor.ExecuteScript("$('#HowHear').data('kendoDropDownList').value('Ad')");
        }
        [FindsBy(How = How.Id, Using = "BillingStreetNumber")]
        public IWebElement txtBillingStreetNumber { get; set; }

        [FindsBy(How = How.Id, Using = "BillingAddress")]
        public IWebElement txtBillingAddress { get; set; }

        [FindsBy(How = How.Id, Using = "BillingSuburb")]
        public IWebElement txtBillingSuburb { get; set; }

        [FindsBy(How = How.Id, Using = "BillingCity")]
        public IWebElement txtBillingCity { get; set; }

        public void txtBillingPostCode_js(string Postcode)
        {
            executor.ExecuteScript("$('#BillingPostcode').val('" + Postcode + "')");


        }

        [FindsBy(How = How.Id, Using = "BillingCountry")]
        public IWebElement txtBillingCountry { get; set; }

        [FindsBy(How = How.Id, Using = "submitButton")]
        public IWebElement btnsubmitButton { get; set; }



        public RegisteringParentPage_50_ParentProfile TC_CRE_PARENT_01_3_FillParentProfile(IWebDriver driver, string DateOfBirth
                            , string Mobile
                            , string StreetNumber
                            , string Address
                            , string Suburb
                            , string City
                            , string Postcode
                            , string Country, string parent_email
                            , string FirstName
                             , string LastName)
        {
            try
            {
                Utilities.Common.TitleValidation(driver, " Create Parent Profile by Admin", "Edit Contact - aimy plus");

                log.Info("CRE_PARENT_01	Registering a new parent at site level");

                FillInfo(driver, DateOfBirth, Mobile, StreetNumber, Address, Suburb, City, Postcode, Country);

                log.Debug(" Parent Profile DateOfBirth: " + DateOfBirth
                   + " Mobile: " + Mobile
                   + " StreetNumber: " + StreetNumber
                   + " Address: " + Address
                   + " Suburb: " + Suburb
                   + " City: " + City
                   + " Postcode: " + Postcode
                   + " Country: " + Country);

                script = "return document.getElementsByTagName('div')[14].innerText;";

                if (Verify_ParentName(script, "Login: " + parent_email) && Verify_ParentName(script, "Contact: " + parent_email))
                {
                    script = "return document.getElementsByTagName('h5')[2].innerHTML;";


                    if (Verify_ParentName(script, FirstName.Trim()+ " "+ LastName.Trim()))
                    {
                        log.Info("[PASS] CRE_PARENT_01 Registering a new parent at site level");
                        Utilities.Common.TakeScreenShot("CRE_PARENT_01 Registering a new parent at site level");

                    }
                    else // wrong Parent name display
                    {
                        log.Error("[FAIL] CRE_PARENT_01	Registering a new parent at site level");
                        Utilities.Common.TakeScreenShot("FAIL - wrong Parent name displayed TC_CRE_PARENT_01");

                    }
                }
                else // wrong email display
                {
                    log.Error("[FAIL] CRE_PARENT_01	Registering a new parent at site level");
                    Utilities.Common.TakeScreenShot("FAIL - wrong email displayed TC_CRE_PARENT_01");

                }
            }

            catch (Exception e)
            {
                log.Error(e.Message);
                log.Error(e.StackTrace);

            }
            return new RegisteringParentPage_50_ParentProfile();

        }

        public int FillInfo(IWebDriver driver, string DateOfBirth
                            , string Mobile
                            , string StreetNumber
                            , string Address
                            , string Suburb
                            , string City
                            , string Postcode
                           , string Country)
        {
            WebDriverWait wait = new WebDriverWait(Utilities.Common.driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iShortWait));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(btnsubmitButton));

                AimySendKeys(txtDateOfBirth, DateOfBirth);
                txtMobile1_js(Mobile);
                txtLandline1_js("099144100");
                txtOffice1_js("099144123");
                txtOfficeExtension_js("100");
                AimySendKeys(txtStreetNumber, StreetNumber);
                AimySendKeys(txtAddress, Address);
                AimySendKeys(txtSuburb, Suburb);
                AimySendKeys(txtCity, City);

                txtPostCode_js(Postcode);
                AimySendKeys(txtCountry, Country);

                AimySendKeys(txtBillingStreetNumber, StreetNumber);
                AimySendKeys(txtBillingAddress, Address);
                AimySendKeys(txtBillingSuburb, Suburb);
                AimySendKeys(txtBillingCity, City);
                txtBillingPostCode_js(Postcode);
                AimySendKeys(txtBillingCountry, Country);

                LstHowHear_js("");

                Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
                Utilities.Common.TakeScreenShot("TC_CRE_PARENT_01_3_FillParentProfile_BeforeSubmit");
                log.Debug("TC_CRE_PARENT_01_3_FillParentProfile: Enter information for Parent Profile");

                AimyClick(btnsubmitButton);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                log.Error(e.StackTrace);
                Utilities.Common.TakeScreenShot("TC_CRE_PARENT_01_3_FillParentProfile FAIL");
                log.Error("[FAIL] TC_CRE_PARENT_01_3_FillParentProfile: Enter information for Parent Profile.");

                return 1;
            }
            return 0;
        }






    }
}
