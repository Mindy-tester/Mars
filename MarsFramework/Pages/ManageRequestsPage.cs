using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class ManageRequestsPage
    {
        public ManageRequestsPage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region
        //Intilaize web elements

        //click on Recieved Requests
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Received Requests')]")]
        private IWebElement recievedRequests { get; set; }

        //click on sent requests
        [FindsBy(How =How.XPath, Using = "//a[contains(text(),'Sent Requests')]")]
        private IWebElement sentRequests { get; set; }

        #endregion

        public void Requests()
        {

            Actions manageRequestaction = new Actions(Global.GlobalDefinitions.driver);
            manageRequestaction.MoveToElement(Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(text(), 'Manage Requests')]"))).Click().Build().Perform();

            WebDriverWait recievedRequetsWait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            IWebElement recievedRequestObj = recievedRequetsWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Received Requests')]")));
            recievedRequests.Click();

            Actions action = new Actions(Global.GlobalDefinitions.driver);
            action.MoveToElement(Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(text(), 'Manage Requests')]"))).Click().Build().Perform();

            WebDriverWait sentRequetsWait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            IWebElement sentRequestObj = sentRequetsWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Sent Requests')]")));
            sentRequests.Click();
            

            


        }



    }
}
           
