using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AimyTest.Registering_a_parent
{
    public class Child_21_AddAuthorisedPickup : MyElelment
    {
        public Child_21_AddAuthorisedPickup()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);

        }
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // Added by Galen
        // Textbox FirstName
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[1]/div/div/div[2]/div/form/div[1]/div[2]/input")]
        private IWebElement txtFirstName { get; set; }

        // Textbox LastName
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[1]/div/div/div[2]/div/form/div[2]/div[2]/input")]

        private IWebElement txtLastName { get; set; }

        // Textbox Mobile
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[1]/div/div/div[2]/div/form/div[3]/div[2]/input")]
        private IWebElement txtMobile { get; set; }

        // Textbox RelationWithTheChild
        [FindsBy(How = How.Id, Using = "Relation")]
        private IWebElement txtRelationWithTheChild { get; set; }

        // Textbox Comments
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[1]/div/div/div[2]/div/form/div[5]/div[2]/textarea")]
        private IWebElement txtComments { get; set; }


        // Button saveProceedBut
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[1]/div/div/div[2]/div/form/div[7]/div/input[1]")]
        private IWebElement btnsaveProceedBut { get; set; }

        // Button cancelProceedBut
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[1]/div/div/div[2]/div/form/div[7]/div/input[2]")]
        private IWebElement btncancelProceedBut { get; set; }

        // Button SkipPhoto
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div/a[2]")]
        private IWebElement btnSkipPhoto { get; set; }

        public void TC_CRE_CHILD_03_FillAuthorisedPickUp(IWebDriver driver,
                              string FirstName,
                              string LastName,
                              string Mobile,
                              string Gender,
                              string RelationWithChild,
                              string Comments)
        {
            FillInfo(driver, FirstName, LastName, Mobile, Gender, RelationWithChild, Comments);
            try
            {
                log.Debug("Submitted the authorised pick up with FirstName: " + FirstName
                                  + " LastName: " + LastName
                       + " Relationship to the child: " + RelationWithChild
                      + " Mobile: " + Mobile
                      + " Gender: " + Gender
                      + " Comments: " + Comments);
                // 1stAuthorisePickup
                script = " return document.getElementsByClassName('col-sm-7')[3].innerHTML;";
                if (Verify_ParentChildInfo(script, "<b>Name :</b>  "+ FirstName+ " "+ LastName, "<b>Mobile :</b>", " <b>Relationship :</b> " + RelationWithChild, "<b>Comment :</b> " + Comments))
                {
                    log.Info("[Pass step] Enroll a new child - 1stAuthorisePickup info in viewing Child Profile verified");

                }
                else // wrong info displayed
                {
                    log.Error("[FAIL step] Enroll a new child - wrong 1stAuthorisePickup info displayed");
                    Utilities.Common.TakeScreenShot("FAIL - Enroll a new child");

                }

            }
            catch (Exception e)
            {
                log.Error(e.Message);
                Utilities.Common.TakeScreenShot("TC_CRE_CHILD_03_FillAuthorisedPickUp FAIL");
                log.Error("TC_CRE_CHILD_03_ Add the authorised pick up, something went wrong: [FAIL]");
            }
        }




        public int FillInfo(IWebDriver driver,
                              string FirstName,
                              string LastName,
                              string Mobile,
                              string Gender,
                              string RelationWithChild,
                              string Comments)
        {
            WebDriverWait wait = new WebDriverWait(Utilities.Common.driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iShortWait));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(btnsaveProceedBut));
                AimySendKeys(txtFirstName, FirstName);
                AimySendKeys(txtLastName, LastName);
                AimySendKeys(txtMobile, Mobile);
                AimySendKeys(txtRelationWithTheChild, RelationWithChild);
                AimySendKeys(txtComments, Comments);

                Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
                Utilities.Common.TakeScreenShot("TC_CRE_CHILD_03_FillAuthorisedPickUp");
                log.Info("[PASS] TC_CRE_CHILD_03_FillAuthorisedPickUp: Add the authorised pick up");

                AimyClick(btnsaveProceedBut);
                wait.Until(ExpectedConditions.ElementToBeClickable(btnSkipPhoto));
                AimyClick(btnSkipPhoto);

            }
            catch (Exception e)
            {
                log.Error(e.Message);
                Utilities.Common.TakeScreenShot("TC_CRE_CHILD_03_FillAuthorisedPickUp FAIL");
                log.Error("TC_CRE_CHILD_03_FillAuthorisedPickUp: Add the authorised pick up: [FAIL]");
                return 1;
            }
            return 0;
        }


    }
}