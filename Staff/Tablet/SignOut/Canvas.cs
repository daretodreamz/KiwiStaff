using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace AimyTest.Tablet.SignOut
{
    public class Canvas : MyElelment
    {
        // Next button
        [FindsBy(How = How.Id, Using = "canvas")]
        private IWebElement canvas { get; set; }

        public bool DrawSignature(IWebDriver driver)
        {
            Actions builder = new Actions(driver);
            IAction drawAction = builder.MoveToElement(canvas, 20, 20)
                .ClickAndHold()
                .MoveByOffset(80, 80)
                .MoveByOffset(50, 20)
                .Release()
                .Build();
            drawAction.Perform();
            return true;
        }
    }
}
