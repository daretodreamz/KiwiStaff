

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;


namespace AimyTest.Registering_a_parent
{
    public class Child_1_Enrollment : MyElelment
    {

        public Child_1_Enrollment()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);

        }
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        private IJavaScriptExecutor executor = Utilities.Common.driver as IJavaScriptExecutor;
        // Textbox FirstName
        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement txtFirstName { get; set; }

        // Textbox FirstName
        [FindsBy(How = How.Id, Using = "MiddleName")]
        private IWebElement txtMiddleName { get; set; }

        // Textbox LastName
        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement txtLastName { get; set; }

        // Textbox DateOfBirth
        [FindsBy(How = How.Id, Using = "DateOfBirth")]
        public IWebElement txtDateOfBirth { get; set; }

        // Checkbox Gender
        [FindsBy(How = How.Id, Using = "maleRadio")]
        public IWebElement chkGender { get; set; }

        // Checkbox Gender
        [FindsBy(How = How.Id, Using = "maleRadio")]
        public IWebElement Site { get; set; }

        //Site dropdown list
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[1]/form/div[9]/div/span[1]/span/span[1]")]
        private IWebElement cmbSite { get; set; }

        // Button Submit
        [FindsBy(How = How.Id, Using = "saveProceedBut")]
        private IWebElement btnsubmitButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='childRegForm']/div[14]/div[2]/div/div/span[2]")]
        private IWebElement Lbglass { get; set; }

        // Button Skip Medical condition
        [FindsBy(How = How.XPath, Using = ".//*[@id='body-container']/form/div/div[18]/div/a")]
        private IWebElement btnSkipMedicalCondition { get; set; }

        // Button Update Picture Profile
        [FindsBy(How = How.XPath, Using = ".//*[@id='body-container']/div/a[2]")]
        private IWebElement btnSkipPhoto { get; set; }

        // Button Proceed booking
        [FindsBy(How = How.XPath, Using = ".//*[@id='body-container']/div[3]/div/div/div[15]/div/div/a[2]")]
        private IWebElement btnChildBooking { get; set; }

        private void YesNo(IWebDriver driver, int YesOrNo)
        {

            Console.WriteLine("Test value of textbox" + Lbglass.Text);
            WebDriverWait wait = new WebDriverWait(Utilities.Common.driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iMediumWait));
            wait.Until(ExpectedConditions.ElementToBeClickable(Lbglass));

            IWebElement test = Utilities.Common.driver.FindElement(By.XPath(".//*[@id='childRegForm']/div[14]/div[2]/div"));
            string tmp = test.GetAttribute("class");
            if (tmp.Contains("bootstrap-switch-off"))
            {
                AimyClick(Lbglass);
            }

        }
        private void txtSchoolName_js(IWebDriver driver, string SchoolName, string siteID)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iShortWait));
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iMediumWait);
            try
            {
                log.Debug("Selecting a school to enroll");
                Utilities.Common.SelectSchoolName_frmPopUp(driver, SchoolName);

                // select site
                log.Debug("Selecting a site to enroll");
                executor.ExecuteScript("$('#SiteNameToSelect').data('kendoDropDownList').value(" + siteID + ");");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        private int FillInformation(IWebDriver driver
                            , string DateOfBirth
                            , string FirstName
                            , string MiddleName
                            , string LastName
                            , string Gender
                            , string SchoolName
                            , string SiteID)

        {
            WebDriverWait wait = new WebDriverWait(Utilities.Common.driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iShortWait));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(btnsubmitButton));
                Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iMediumWait);

                AimySendKeys(txtFirstName, FirstName);
                AimySendKeys(txtMiddleName, MiddleName);
                AimySendKeys(txtLastName, LastName);
                AimyClick(chkGender);
                Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iMediumWait);
                AimySendKeys(txtDateOfBirth, DateOfBirth);

                Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iMediumWait);

                txtSchoolName_js(driver, SchoolName, SiteID);

                Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iMediumWait);

                Utilities.Common.TakeScreenShot("TC_CRE_CHILD_01_FillInformation");

                AimyClick(btnsubmitButton);

                log.Debug("Child info entered: DOB " + DateOfBirth
                           + " FirstName: " + FirstName
                           + " LastName: " + LastName
                           + " Child ID:" + Utilities.Common.GetParentID());
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                log.Error(e.StackTrace);

                Utilities.Common.TakeScreenShot("TC_CRE_CHILD_01_FillInformation FAIL");
                log.Error("TC_CRE_CHILD_01_FillInformation: Enroll a new child: [FAIL]");
                return 1;
            }
            return 0;

        }



        public Child_20_Profile TC_CRE_CHILD_01_FillInformation(IWebDriver driver
                           , string DateOfBirth
                           , string FirstName
                           , string MiddleName
                           , string LastName
                           , string Gender
                           , string SchoolName
                           , string SiteID
                           , bool isMedicalCondition
                           , bool isPhoto)
        {
            FillInformation(driver, DateOfBirth, FirstName.Trim(), MiddleName.Trim(), LastName.Trim(), Gender, SchoolName.Trim(), SiteID.Trim());

            WebDriverWait wait = new WebDriverWait(Utilities.Common.driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iMediumWait));


            if (!isMedicalCondition)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(btnSkipMedicalCondition));
                AimyClick(btnSkipMedicalCondition);
            }
            else
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(btnSkipMedicalCondition));
                Child_22_MedicalCondition Medical = new Child_22_MedicalCondition();
                Medical.TC_CRE_CHILD_07_MedicalCondition(1, "Medical Name of testing", "High", "Red face", "Relaxing");

            }
            if (!isPhoto)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(btnSkipPhoto));
                AimyClick(btnSkipPhoto);
                /// upload photo here

            }
            log.Info("-----------------Verify information displayed in Child profile-------------------------");

            script = " return document.getElementsByClassName('col-sm-3')[1].innerHTML;";
            // Child info displayed
            if (Verify_ParentChildInfo(script, "<b>Name:</b> "+ FirstName.Trim()+ " "+ MiddleName.Trim() + " " + LastName.Trim(), "Date of Birth:</b>", "Age:</b> ", "<b>Known As:</b>"))
            {
                log.Info("[Pass step] Enroll a new child -Profile info verified");
                log.Error("NEED TO verify for DOB, Age and KnownAs");


            }
            else // wrong Child info displayed
            {
                log.Error("[FAIL step] Enroll a new child - wrong Child info displayed");
                Utilities.Common.TakeScreenShot("FAIL - Enroll a new child");

            }
            try
            {
                script = " return document.getElementsByClassName('col-sm-5')[0].innerHTML;";
                // School in Viewing Profile info verified
                if (Verify_ParentName(script, "</b> Testing School"))
                {
                    log.Info("[Pass step] Enroll a new child - School in Viewing Profile info verified");

                }
                else // wrong School in Viewing Profile info verified
                {
                    log.Error("[Fail step] Enroll a new child - wrong School in Viewing Profile info displayed");
                    Utilities.Common.TakeScreenShot("FAIL - School in View Profile");

                }
                script = " return document.getElementsByClassName('col-md-8')[14].innerHTML;";
              
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                log.Error(e.StackTrace);

                Utilities.Common.TakeScreenShot("TC_CRE_CHILD_01 something wen wrong FAIL");
                log.Error("[FAIL] TC_CRE_CHILD_01 Enroll a new child, something wen wrong.");

            }
            return new Child_20_Profile();
        }


        public Child_20_Profile Edit_ChildInfo(IWebDriver driver
                                   , string DateOfBirth
                                   , string FirstName
                                   , string MiddleName
                                   , string LastName
                                   , string Gender
                                   , string SchoolName
                                   , string SiteName)
        {
            FillInformation(driver, DateOfBirth, FirstName, MiddleName, LastName, Gender, SchoolName, SiteName);

            return new Child_20_Profile();
        }

    }
}
