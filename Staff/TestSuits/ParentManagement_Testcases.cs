using System;
using AimyTest.Deleting_a_parent;
using AimyTest.Utilities;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AimyTest.TestSuits
{
   
    [TestFixture]
    public class ParentManagement_Testcases : TestBase
    {

        public static readonly log4net.ILog log = Utilities.LogHelper.GetLogger();
        
        //private ParentManagementPage handle = null;

        //public ParentManagement_Testcases(): base()
        //{
        //    var handle = new ParentManagementPage();
        //}

        [Test]
        public void DEL_PARENT_01_No_Children()
        {
            var handle = new ParentManagementPage();
            handle.AchiveParentWithoutChildren(Common.driver);
        }
     

    }
}

