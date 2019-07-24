using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Global
{
     public class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static string ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        #endregion

        #region reports
        public static ExtentTest Test;
        public static ExtentReports Extent;
        #endregion

        #region setup and tear down
        //[SetUp]
        [BeforeScenario]
        public void Inititalize()
        {

            // advisasble to read this documentation before proceeding http://extentreports.relevantcodes.com/net/
            switch (Browser)
            {

                case 1:
                    GlobalDefinitions.driver = new FirefoxDriver();
                    break;
                case 2:
                    GlobalDefinitions.driver = new ChromeDriver();
                    GlobalDefinitions.driver.Manage().Window.Maximize();
                    break;

            }

            #region Initialise Reports

            Extent = new ExtentReports(ReportPath, true, DisplayOrder.NewestFirst);
            Extent.LoadConfig(MarsResource.ReportXMLPath);

            #endregion

            //if (MarsResource.IsLogin == "true")
            //{
            //    SignIn loginobj = new SignIn();
            //    loginobj.LoginSteps();
            //}
            //else
            //{
            //    SignUp obj = new SignUp();
            //    obj.register();
            //}

        }


        // [TearDown]

        [AfterScenario]
        public void TearDown()
        {
            // Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");
            // end test. (Reports)
            Extent.EndTest(Test);
            // calling Flush writes everything to the log file (Reports)
            Extent.Flush();
            Thread.Sleep(1000);
            //Close the driver           
            GlobalDefinitions.driver.Quit();
        }
        #endregion

    }
}