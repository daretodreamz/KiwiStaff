

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AimyTest.Registering_a_parent
{
    public class RegisteringParentPage_51_Add2ndParent : MyElelment
    {
        private IJavaScriptExecutor executor = Utilities.Common.driver as IJavaScriptExecutor;

        public RegisteringParentPage_51_Add2ndParent()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);

        }
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // Login button
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/form/div/div[1]/div[2]/a")]
        public IWebElement btnSelectPhoto { get; set; }

        // Textbox FirstName
        [FindsBy(How = How.Id, Using = "FirstName2")]
        private IWebElement txtFirstName { get; set; }

        // Textbox LastName
        [FindsBy(How = How.Id, Using = "LastName2")]
        private IWebElement txtLastName { get; set; }

        // Textbox Contact Email 
        [FindsBy(How = How.Id, Using = "Email2")]
        private IWebElement txtEmail { get; set; }

        // Textbox Relationship
        [FindsBy(How = How.Id, Using = "Relation2")]
        private IWebElement txtRelationship { get; set; }

        // Textbox Mobile
        public void txtMobile_js(string Mobile)
        {
            executor.ExecuteScript("$('#Mobile2').val('" + Mobile + "')");

        }

        // Textbox HomePhone
        public void txtHomePhone_js(string Mobile)
        {
            executor.ExecuteScript("$('#Landline2').val('" + Mobile + "')");
        }

        // Textbox Work Phone
        public void txtWorkPhone_js(string Mobile)
        {
            executor.ExecuteScript("$('#Office2').val('" + Mobile + "')");
        }


        // Button Submit
        [FindsBy(How = How.Id, Using = "submitButton1")]
        private IWebElement btnsubmitButton { get; set; }

        // Uploading a Photo

        // Button Select an image file
        [FindsBy(How = How.XPath, Using = ".//*[@id='fu-my-simple-upload']")]
        private IWebElement btnSelectingFile { get; set; }

        // Button Cancel Selecting an image file
        [FindsBy(How = How.XPath, Using = ".//*[@id='tbx-file-path']")]
        private IWebElement btnCancelSelectingFile { get; set; }

        // Button Rotate a picture
        [FindsBy(How = How.XPath, Using = ".//*[@id='body-container']/div[1]/div/div/div[7]/div/div[1]/a")]
        private IWebElement btnRotateImage { get; set; }

        // Button Drop a Picture
        [FindsBy(How = How.XPath, Using = ".//*[@id='hl-crop-image']")]
        private IWebElement btnDropImage { get; set; }

        // Button Save Picture
        [FindsBy(How = How.XPath, Using = ".//*[@id='btn-my-submit']")]
        private IWebElement btnSaveImage { get; set; }

        public void AddNewPhoto(IWebDriver driver)
        {
            AimyClick(btnSelectPhoto);
            Console.WriteLine(" Selecting Photo");

            AimyClick(btnSelectingFile);
            Console.WriteLine(" Selecting file");
            driver.FindElement(By.Name("files")).SendKeys("C:\\Users\\KEVIN\\Desktop\\IMG_7180.jpg");
            AimyClick(btnRotateImage);

        }

        public void TC_CRE_PARENT_02_FillSecondParentInfo(IWebDriver driver
                            , string email
                            , string FirstName
                            , string LastName
                            , string Relationship
                            , string Mobile
                            , string HomePhone
                            , string WorkPhone)
        {
            Utilities.Common.TitleValidation(Utilities.Common.driver, " Create 2nd Parent Profile by Admin", "SecondParent - aimy plus");

            FillInfo(driver, email, FirstName, LastName, Relationship, Mobile, HomePhone, WorkPhone);


            log.Debug(" Submitted a Second Parent: Email: " + email
                              + " FirstName: " + FirstName
                              + " LastName: " + LastName
                   + " Relationship to the child: " + Relationship
                  + " Mobile: " + Mobile
                  + " HomePhone: " + HomePhone
                  + " WorkPhone: " + WorkPhone);

            script = "return document.getElementsByTagName('h4')[0].innerHTML;";

            if (Verify_ParentName(script, "<b>" + FirstName.Trim()+" "+ LastName.Trim()))
            {
                log.Info("[PASS] REG_PARENT_02	Registering a new second parent");
                Utilities.Common.TakeScreenShot("REG_PARENT_02 Registering a new second parent");

            }
            else // wrong parent name display
            {
                log.Error("[FAIL] REG_PARENT_02	Registering a new second parent");
                Utilities.Common.TakeScreenShot("FAIL- REG_PARENT_02 Registering a new second parent");

            }

            Utilities.Common.TitleValidation(Utilities.Common.driver, " Back to Parent Profile by Admin", "Profile - aimy plus");

            // return new RegisteringParentPage5_ParentProfile();
        }

        public int FillInfo(IWebDriver driver
                            , string email
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
                AimySendKeys(txtEmail, email);
                AimySendKeys(txtFirstName, FirstName);
                AimySendKeys(txtLastName, LastName);
                AimySendKeys(txtRelationship, Relationship);

                txtMobile_js(Mobile);
                txtHomePhone_js(HomePhone);
                txtWorkPhone_js(WorkPhone);
                Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
                Utilities.Common.TakeScreenShot("FillSecondParentInfo_BeforeSubmit");
                log.Debug("FillSecondParentInfo");

                AimyClick(btnsubmitButton);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                log.Error(e.StackTrace);

                Utilities.Common.TakeScreenShot("TC_CRE_PARENT_02_FillSecondParentInfo FAIL");
                log.Error("[Fail] TC_CRE_PARENT_02_FillSecondParentInfo: Enter information to create a second parent");
                return 1;
            }
            return 0;
        }

    }
}
