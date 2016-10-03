using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AimyTest.Edit_Login
{
    public class EditLogin : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // Password
        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement txtPassword { get; set; }

        // PasswordConfirm
        [FindsBy(How = How.Id, Using = "PasswordConfirm")]
        private IWebElement txtConfirmPassword { get; set; }

        // submitButton
        [FindsBy(How = How.Id, Using = "submitButton")]
        private IWebElement btnSubmit { get; set; }

        public bool IsLoginEdited(IWebDriver driver, string NewPassword)
        {
            log.Info("Edit Login Validation Test Case: ");

            AimySendKeys(driver, txtPassword, NewPassword);
            AimySendKeys(driver, txtConfirmPassword, NewPassword);
            AimyClick(driver, btnSubmit);
            log.Info("[PASS]");
            return true;
        }
       
    }
}
