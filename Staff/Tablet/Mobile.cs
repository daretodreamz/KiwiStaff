using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AimyTest.Tablet
{
    public class Mobile : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // Driver Pickup
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[1]/div[5]/div[1]/a")]
        private IWebElement btnDriverPickup { get; set; }
        // SignIn
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[1]/div[5]/div[2]/a")]
        private IWebElement btnSignIn { get; set; }
        // SignOut
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[1]/div[5]/div[3]/a")]
        private IWebElement btnSignOut { get; set; }

        public enum GreenRedOptions
        {
            Green,
            Red
        }

        public enum ProgrammesOptions
        {
            BSC,
            ASC
        }


        public bool ClickOnDriverPickup(IWebDriver driver, GreenRedOptions greenRedFlag, string whichChild)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            AimyClick(driver, btnDriverPickup);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            Pages.SchoolListPage.ClickOnNext(driver);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            if (greenRedFlag == GreenRedOptions.Green)
            {
                Pages.ChildListPage.ClickOnGreenTick(driver, whichChild);
            }
            else if(greenRedFlag == GreenRedOptions.Red)
            {
                Pages.ChildListPage.ClickOnRedTick(driver, whichChild);
                Pages.ChildListPage.ChooseOtherReason(driver);
            }
            
            return true;
        }

        public bool ClickOnSignIn(IWebDriver driver, GreenRedOptions greenRedFlag, string whichChild, ProgrammesOptions whichProg = ProgrammesOptions.ASC)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnSignIn);
            Common.WaitBySleeping(GlobalVariable.iShortWait*20);
            if(whichProg == ProgrammesOptions.ASC)
            {
                Pages.ChildSignInPage.ClickOnChildSignIn(driver, whichChild, whichProg);
                Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
                if (greenRedFlag == GreenRedOptions.Green)
                {
                    Pages.SignInRollCallPage.ClickOnGreenTick(driver, whichChild);
                }
                else if (greenRedFlag == GreenRedOptions.Red)
                {
                    Pages.SignInRollCallPage.ClickOnRedTick(driver, whichChild);
                    Pages.SignInRollCallPage.ChooseOtherReason(driver);
                }
            }
            else { }           
            return true;
        }

        public bool ClickOnSignOut(IWebDriver driver, string whichChild)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnSignOut);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            if (!Pages.ChildSignOutPage.ClickOnChildSignOut(driver))
                return false;
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            if (!Pages.SignYourChildOutPage.ClickOnGreenTick(driver, whichChild))
                return false;
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            Pages.AuthorisedPickupsDialogPage.ClickOnAuthPickup(driver);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            Pages.CanvasPage.DrawSignature(driver);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            Assert.AreEqual(true, Pages.CanvasPage.ClickOnConfirm(driver));
            return true;
        }
    }
}
