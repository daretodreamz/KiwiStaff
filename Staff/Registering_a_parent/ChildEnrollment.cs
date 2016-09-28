

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;


namespace AimyTest.Registering_a_parent
{
    public class ChildEnrollment
    {

        public ChildEnrollment()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);

        }

        private IJavaScriptExecutor executor = Utilities.Common.driver as IJavaScriptExecutor;
        private static readonly log4net.ILog log = Utilities.LogHelper.GetLogger();
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
                Lbglass.Click();
            }

        }
        private void txtSchoolName_js(IWebDriver driver, string SchoolName, string siteID)
        {
            executor.ExecuteScript("document.getElementById('SchoolName').focus()");
            driver.FindElement(By.Id("SchoolName")).Click();
            executor.ExecuteScript("$('#category').val('" + SchoolName + "');");
            executor.ExecuteScript("$('#category').keyup();");
            // How to select from Grid 
            log.Debug("selecting a school");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Utilities.GlobalVariable.iMediumWait));

            try
            {
  
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iLongWait));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[3]/div[2]/div/div/div[2]/div[2]/div[3]/table/tbody/tr/td[3]/a")));
                var button = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div[2]/div[2]/div[3]/table/tbody/tr/td[3]/a"));
                button.Click();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            // select site
            executor.ExecuteScript("$('#SiteNameToSelect').data('kendoDropDownList').value(" + siteID + ");");
        }


        public void FillInformation(IWebDriver driver
                            , string DateOfBirth
                            , string FirstName
                            , string MiddleName
                            , string LastName
                            , string Gender
                            , string SchoolName
                             , string SiteID

                            , bool IsBooking
                            )
        {
            txtDateOfBirth.SendKeys(DateOfBirth);
            txtFirstName.SendKeys(FirstName);
            txtMiddleName.SendKeys(MiddleName);
            txtLastName.SendKeys(LastName);
            chkGender.Click();
            txtSchoolName_js(driver, SchoolName, SiteID);

            WebDriverWait wait = new WebDriverWait(Utilities.Common.driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iMediumWait));

            wait.Until(ExpectedConditions.ElementToBeClickable(btnsubmitButton));

            btnsubmitButton.Click();

            log.Info("Child info entered: DOB " + DateOfBirth
                       + " FirstName: " + FirstName
                       + " LastName: " + LastName
                       + " Child ID:" + Utilities.Common.GetParentID());

            wait.Until(ExpectedConditions.ElementToBeClickable(btnSkipMedicalCondition));
            btnSkipMedicalCondition.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(btnSkipPhoto));
            btnSkipPhoto.Click();
            /// upload photo here

            /// Do booing if need
            if (IsBooking)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(btnChildBooking));
                btnChildBooking.Click();
            }


        }


    }
}
