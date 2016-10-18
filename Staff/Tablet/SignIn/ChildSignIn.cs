using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using static AimyTest.Tablet.Mobile;

namespace AimyTest.Tablet.SignIn
{
    public class ChildSignIn : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // ASC button
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[2]/div[3]/ul/li[1]/a/div/div[1]/h1")]
        private IWebElement btnASC { get; set; }

        // BSC button
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[2]/div[3]/ul/li[2]/a/div/div[1]/h1")]
        private IWebElement btnBSC { get; set; }

        public bool ClickOnChildSignIn(IWebDriver driver, string whichChild, ProgrammesOptions whichProg)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            if (whichProg == ProgrammesOptions.ASC)
                AimyClick(driver, btnASC);
            else AimyClick(driver, btnBSC);
            return true;
        }
    }
}
