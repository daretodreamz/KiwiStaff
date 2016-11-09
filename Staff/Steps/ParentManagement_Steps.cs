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
        private readonly IWebDriver driver;
        private readonly ScenarioContext scenarioContext;

        public ParentManagement_Steps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;
            this.driver = this.scenarioContext["DriverContext"] as IWebDriver;
        }

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
                this.scenarioContext.Set(name.ParentName, "ParentName");
            }
        }
        
        [When(@"I have clicked on Archive button")]
        public void WhenIHaveClickedOnArchiveButton()
        {
            Pages.ParentManagementPage.AchiveParent(driver, scenarioContext.Get<String>("ParentName"));
            Common.WaitBySleeping(GlobalVariable.iShortWait);
        }

        [When(@"Parent is moved to Archive tab")]
        public void WhenParentIsMovedToArchiveTab()
        {
            Pages.ParentManagementPage.GoToAchivePage(driver);
            Assert.AreEqual(true, Pages.ParentManagementPage.FindTheParent(driver, scenarioContext.Get<String>("ParentName")));
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

        [Given(@"Open Archive list")]
        public void GivenOpenArchiveList()
        {
            Pages.ParentManagementPage.GoToAchivePage(driver);            
        }

        [When(@"I have clicked on Restore button")]
        public void WhenIHaveClickedOnRestoreButton()
        {
            Assert.AreEqual(true, Pages.ParentManagementPage.FindTheParent(driver, scenarioContext.Get<String>("ParentName")));
            Pages.ParentManagementPage.RestoreArchivedParent(driver, scenarioContext.Get<String>("ParentName"));
        }

        [Then(@"Parent is moved to Management tab")]
        public void ThenParentIsMovedToManagementTab()
        {
            Assert.AreEqual(true,
                 Pages.ParentManagementPage.IsParentBeenRestoredFromAchiveList(driver, scenarioContext.Get<String>("ParentName")));
            Assert.AreEqual(true,
                Pages.ParentManagementPage.IsParentBeenRestoredToParentManagePage(driver, scenarioContext.Get<String>("ParentName")));
        }

        [Then(@"Parent can log in to Aimy by the following credentials")]
        public void ThenParentCanLogInToAimyByTheFollowingCredentials(Table table)
        {
            Pages.ParentManagementPage.LogoutAdminPort(driver);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            IEnumerable<dynamic> credentials = table.CreateDynamicSet();
            foreach (var users in credentials)
            {
                string uname = users.Username;
                int upass = users.Password;
                Assert.AreEqual(true,
                Pages.ParentManagementPage.LoginParentPortalDefault(driver, uname, upass.ToString()));
            }
        }

        [Then(@"Parent can make a booking")]
        public void ThenParentCanMakeABooking()
        {
            Pages.ParentDashBoardPage.DoBookingForChild(driver);
            Assert.AreEqual(true, Pages.BookingPage.BookingWizard(driver));
        }
    }
}
