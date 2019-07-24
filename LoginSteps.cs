using MarsFramework.Global;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace MarsFramework
{
    [Binding]
    public class LoginSteps : Global.Base
    {
        [Given(@"I have entered the url")]
        public void GivenIHaveEnteredTheUrl()
         {
           // Global.GlobalDefinitions.driver = new ChromeDriver();

            //Populate the Excel sheet
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "SignIn");

            //Navigate to the Url
            Global.GlobalDefinitions.driver.Navigate().GoToUrl(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

        }
        
        [Given(@"I have entered username and password")]
        public void GivenIHaveEnteredUsernameAndPassword()
        {
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//a[@class='item']")).Click();


            // Finding the Email Field
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='Email address']")).SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Username"));

            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Finding the Password Field
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Password"));
            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        
        [When(@"I press login")]
        public void WhenIPressLogin()
                    {
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//button[contains(text(), 'Login')]")).Click();
        }
        
        [Then(@"I should be on the home page")]
        public void ThenIShouldBeOnTheHomePage()
        {
            
            var logo = Global.GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(),'Mars Logo')]")).Text;
            //Console.WriteLine(text);
            Thread.Sleep(1000);

            if (logo == "Mars Logo")
            {
                Global.Base.Test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Login Successful");
            }
            else
            {
                Global.Base.Test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Login Unsuccessful");

            }
        }
    }
}
