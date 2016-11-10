using NUnit.Framework;
using System;
using AimyTest.Browsers;

namespace AimyTest.TestSuits
{
    [TestFixture]
    public class TestBase
    {
       private static readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        [SetUp]
        public void SetupTest()
        {

            //////////////Utilities.Common.driver = new ChromeDriver();
            
            // write the start time to log file

            log.Info("---------------------------------------------------------------------");
            log.Info("Test Execution is started |  Start Time : " + DateTime.Now.ToString());
            log.Info("---------------------------------------------------------------------");

            // login to aimy
            //Utilities.Common.driver.Navigate().GoToUrl(Utilities.GlobalVariable.sURL);
            ////////////Login pgLogin = new Login();
            ////////////pgLogin.LoginAimy(Utilities.Common.driver, Utilities.GlobalVariable.sloginUsername, Utilities.GlobalVariable.sloginPassword);

        }
        [TearDown]
        public void Closing()
        {
            // write the end time to log file
           
            log.Info("---------------------------------------------------------------------");
            log.Info("Test Execution is ended |  End Time : " + DateTime.Now.ToString());
            log.Info("---------------------------------------------------------------------");

            ChromeBrowser.Close();
            ChromeBrowser.Quite();
        }
    }
}
