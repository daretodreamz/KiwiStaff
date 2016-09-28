using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AimyTest.Registering_a_parent
{
    public class RegisteringParentPage_50_ParentProfile : MyElelment
    {
        private IJavaScriptExecutor executor = Utilities.Common.driver as IJavaScriptExecutor;

        public RegisteringParentPage_50_ParentProfile()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);

        }
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // link to add new second parent
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[1]/div/div/div[5]/div/div/a")]
        public IWebElement lnkAddSecondParent { get; set; }

        // link to Add 1stEmergencyContact
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[1]/div/div/div[7]/div/div[1]/a")]
        public IWebElement lnkAdd1stEmergencyContact { get; set; }

        // link to Add 2ndEmergencyContact
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[1]/div/div/div[7]/div/div[2]/a")]
        public IWebElement lnkAdd2ndEmergencyContact { get; set; }

        // link to Add New Child
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[1]/div/div/div[8]/div/div/div[1]/div/h5[2]/a")]
        public IWebElement lnkAddNewChild { get; set; }

        // Uploading profile photo
        [FindsBy(How = How.LinkText, Using = "select a photo")]
        public IWebElement btnsSelectPhoto { get; set; }

        //uploading file
        [FindsBy(How = How.Name, Using = "MyFile")]
        public IWebElement btnSelectFilePicture { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='hl-rotate-image']")]
        public IWebElement btnRotate { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='hl-crop-image']")]
        public IWebElement btnCropImage { get; set; }

        [FindsBy(How = How.Id, Using = "btn-my-submit")]
        public IWebElement btnSaveImg { get; set; }
        // adding more field for assertion

        // navigation to another pages
        public RegisteringParentPage_51_Add2ndParent AddSecondParent(IWebDriver driver)
        {
            AimyClick(lnkAddSecondParent);
            log.Debug("AddSecondParent starts...");
            return new RegisteringParentPage_51_Add2ndParent();
        }
        public RegisteringParentPage_52_Add1stEmergency Add1stEmergencyContact(IWebDriver driver)
        {
            AimyClick(lnkAdd1stEmergencyContact);

            log.Debug("Add1stEmergencyContact starts...");
            return new RegisteringParentPage_52_Add1stEmergency();
        }
        public RegisteringParentPage_53_Add2ndEmergency Add2ndEmergencyContact(IWebDriver driver)
        {
            AimyClick(lnkAdd2ndEmergencyContact);
            log.Debug("Add2ndEmergencyContact starts...");
            return new RegisteringParentPage_53_Add2ndEmergency();
        }

        public Child_1_Enrollment AddNewChild(IWebDriver driver)
        {
            AimyClick(lnkAddNewChild);

            log.Debug("AddNewChild starts...");

            return new Child_1_Enrollment();
        }

        // add test cases for UI validation here
        public void UploadPicture()
        {

            AimyClick(btnsSelectPhoto);
            Utilities.Common.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(300));

            // Upload a picture

            var SelectFile = Utilities.Common.driver.FindElement(By.Name("MyFile"));
            SelectFile.SendKeys("C:/Users/Hanh/Dropbox/Automation/MyClassBased_PageObjects_PageObjects/ClassBased_PageObjects/img/girl.JPG");
            log.Debug("Getting picture");


            WebDriverWait wait = new WebDriverWait(Utilities.Common.driver, TimeSpan.FromSeconds(1000));
            log.Debug("Current Timeout :" +wait.Timeout);

            AimyClick(btnRotate);

         
            Utilities.Common.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(500));
            wait.Until(ExpectedConditions.ElementToBeClickable(btnCropImage));
            AimyClick(btnCropImage);

           log.Debug("drop picture");

            // save picture        
           
            wait.Until(ExpectedConditions.ElementToBeClickable(btnSaveImg));
            log.Debug("Saving a picture");
            AimyClick(btnSaveImg);
          
        }
    }
}

