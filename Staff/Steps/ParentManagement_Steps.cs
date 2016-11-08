using AimyTest.Browsers;
using AimyTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AimyTest.Steps
{
   [Binding]
    public sealed class ParentManagement_Steps
    {
        public static readonly log4net.ILog log = Utilities.LogHelper.GetLogger();
        private IWebDriver driver = Pages.GetDriver();
        private string pn = null;

        [Given(@"Goto Parent management Page")]
        public void GivenGotoParentManagementPage()
        {
            driver.Navigate().GoToUrl(GlobalVariable.sURL + "Parent/Management");
        }

        [Given(@"get the parent name")]
        public void GivenGetTheParentName(Table table)
        {
            IEnumerable<dynamic> names = table.CreateDynamicSet();
            foreach (var name in names)
            {
                pn = name.ParentName;
            }
    }
        
        [When(@"I have clicked on Archive button")]
        public void WhenIHaveClickedOnArchiveButton()
        {
            Pages.ParentManagementPage.AchiveParent(driver, pn);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
        }

        [When(@"Parent is moved to Archive tab")]
        public void WhenParentIsMovedToArchiveTab()
        {
            Pages.ParentManagementPage.GoToAchivePage(driver);
            Assert.AreEqual(true, Pages.ParentManagementPage.FindTheParent(driver, pn));
        }

        [Then(@"Parent cannot log in to Aimy by the following credentials")]
        public void ThenParentCannotLogInToAimyByTheFollowingCredentials(Table table)
        {
            Pages.ParentManagementPage.LogoutAdminPort(driver);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            IEnumerable<dynamic> credentials = table.CreateDynamicSet();
            foreach (var users in credentials)
            {
                string uname = users.Username;
                int upass = users.Password;
                Assert.AreEqual(true,
                Pages.ParentManagementPage.LoginParentPortalDefault(driver, uname, upass.ToString(), false));
            }         
        }
    }
}
