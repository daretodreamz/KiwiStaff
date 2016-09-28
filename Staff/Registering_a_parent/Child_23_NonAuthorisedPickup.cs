using System;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AimyTest.Registering_a_parent
{
    public class Child_23_NonAuthorisedPickup: MyElelment
    {
        public Child_23_NonAuthorisedPickup()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);
        }
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();


        // Textbox FirstName
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div/div/div[2]/div/form/div[1]/div[2]/input")]
        private IWebElement txtFirstName { get; set; }

        // Textbox LastName
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div/div/div[2]/div/form/div[2]/div[2]/input")]

        private IWebElement txtLastName { get; set; }

        // Textbox Mobile
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div/div/div[2]/div/form/div[3]/div[2]/input")]
        private IWebElement txtMobile { get; set; }

        // Textbox RelationWithTheChild
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div/div/div[2]/div/form/div[4]/div[2]/input")]
        private IWebElement txtRelationWithTheChild { get; set; }

        // Textbox WhatToDo
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div/div/div[2]/div/form/div[5]/div[2]/textarea")]
        private IWebElement txtWhatToDo { get; set; }


        // Button saveProceedBut
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div/div/div[2]/div/form/div[7]/div/input[1]")]
        private IWebElement btnsaveProceedBut { get; set; }

        // Button cancelProceedBut
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[2]/div/div/div[2]/div/form/div[7]/div/input[2]")]
        private IWebElement btncancelProceedBut { get; set; }

        // Button SkipPhoto
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/a[2]")]
        private IWebElement btnSkipPhoto { get; set; }


        public void TC_CRE_CHILD_05_Fill_NON_AuthorisedPickUp(IWebDriver driver, string FirstName,
                                            string LastName,
                                            string Mobile,
                                            string Gender,
                                            string RelationWithChild,
                                            string WhatToDo)
        {
            FillInfo(driver, FirstName, LastName, Mobile, Gender, RelationWithChild, WhatToDo);
            try
            {
                log.Debug("Submitted the non-authorised pick up with FirstName: " + FirstName
                                  + " LastName: " + LastName
                       + " Relationship to the child: " + RelationWithChild
                      + " Mobile: " + Mobile
                      + " Gender: " + Gender
                      + " WhatToDo: " + WhatToDo);
                script = " return document.getElementsByClassName('col-sm-7')[4].innerHTML;";
                if (Verify_ParentChildInfo(script, "<b>Name :</b>  " + FirstName + " " + LastName, "<b>Mobile :</b>", " <b>Relationship :</b> " + RelationWithChild, "<b>Action On Arrival :</b> " + WhatToDo))
                {
                    log.Info("[Pass step] Enroll a new child - NonAuthorisePickup info in viewing Child Profile verified");

                }
                else // wrong info displayed
                {
                    log.Error("[FAIL step] Enroll a new child - wrong NonAuthorisePickup info displayed");
                    Utilities.Common.TakeScreenShot("FAIL - Enroll a new child");

                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                log.Error(e.StackTrace);

                Utilities.Common.TakeScreenShot("TC_CRE_CHILD_05_Fill_NON_AuthorisedPickUp FAIL");
                log.Error("TC_CRE_CHILD_05_Fill_NON_AuthorisedPickUp [FAIL]");
            }


        }

        public int FillInfo(IWebDriver driver,
                              string FirstName,
                              string LastName,
                              string Mobile,
                              string Gender,
                              string RelationWithChild,
                               string WhatToDo)
        {
            WebDriverWait wait = new WebDriverWait(Utilities.Common.driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iShortWait));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(btnsaveProceedBut));
                AimySendKeys(txtFirstName, FirstName);
                AimySendKeys(txtLastName, LastName);
                AimySendKeys(txtMobile, Mobile);
                Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iMediumWait);
                AimySendKeys(txtRelationWithTheChild, RelationWithChild);
                AimySendKeys(txtWhatToDo, WhatToDo);

                Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
                Utilities.Common.TakeScreenShot("TC_CRE_CHILD_05_Fill_NON_AuthorisedPickUp");
                log.Info("[PASS] TC_CRE_CHILD_05_Fill_NON_AuthorisedPickUp");

                AimyClick(btnsaveProceedBut);
                wait.Until(ExpectedConditions.ElementToBeClickable(btnSkipPhoto));
                AimyClick(btnSkipPhoto);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                log.Error(e.StackTrace);

                Utilities.Common.TakeScreenShot("TC_CRE_CHILD_05_Fill_NON_AuthorisedPickUp FAIL");
                log.Error("TC_CRE_CHILD_05_Fill_NON_AuthorisedPickUp [FAIL]");
                return 1;
            }
            return 0;
        }

    }
}
