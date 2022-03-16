using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Collections;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


/*
 * Alerts are blocking - they dont allow any action on the page while they are presetn
 * - if alert is present and you try to access a webpage you get UnhandledAlertException
 */

namespace ToolsQA
{
    class AlertsTest
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(@"C:\ChromeDriver");
        }


        //if alert is present and you try to access a webpage you get UnhandledAlertException
        [Test]
        public void TestUnhandledAlert()
        {
            driver.Url = "https://demoqa.com/alerts";
            IWebElement alertBtn = driver.FindElement(By.Id("alertButton"));
            IWebElement otherButton = driver.FindElement(By.Id("confirmButton"));

            //open alert
            alertBtn.Click();

            //try to access another element while alert is present - UnhandledAlertException
            otherButton.Click();
        }

        /*
         * A "simple" alert only has some text and a OK button
         * IAlert is interface to interact with alerts
         * - Accept()
         * - Dismiss()
         * - Text() - gets text on alert dialog
         * - Sendkeys()
         * 
         * driver.SwitchTo().Alert() switches context to alert
         */
        [Test]
        public void TestSimpleAlert()
        {
            driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";
            IWebElement alertBtn = driver.FindElement(By.XPath("//button[text()='Click for JS Alert']"));
            IWebElement result = driver.FindElement(By.Id("result"));

            alertBtn.Click();

            //switch context to alert
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            Thread.Sleep(1000);
            alert.Accept();

            Console.WriteLine("Alert text: {0}, Result: {1}",alertText,result.Text);
        }

        [Test]
        public void TestConfirmAlert()
        {
            driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";
            IWebElement alertBtn = driver.FindElement(By.XPath("//button[text()='Click for JS Confirm']"));
            IWebElement result = driver.FindElement(By.Id("result"));

            alertBtn.Click();

            IAlert alert = driver.SwitchTo().Alert();
            Thread.Sleep(1000);
            //alert.Accept();
            alert.Dismiss();
            
            Console.WriteLine("Alert result: {0}",result.Text);
        }

        [Test]
        public void TestPromptAlert()
        {
            driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";
            IWebElement alertBtn = driver.FindElement(By.XPath("//button[text()='Click for JS Prompt']"));
            IWebElement result = driver.FindElement(By.Id("result"));

            alertBtn.Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys("Testing alert prompt");
            Thread.Sleep(3000);
            alert.Accept();

            Console.WriteLine(result.Text);

        }

        [Test]
        public void TestDelayedAlert()
        {
            driver.Url = "https://demoqa.com/alerts";
            IWebElement alertBtn = driver.FindElement(By.Id("timerAlertButton"));
            WebDriverWait waitForAlert = new WebDriverWait(driver,TimeSpan.FromSeconds(5));

            alertBtn.Click();

            IAlert alert = waitForAlert.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            string alertText = alert.Text;
            Thread.Sleep(3000);
            alert.Accept();

            Console.WriteLine("Found text: {0}",alertText);
        }

        [TearDown]
        public void EndTest()
        {

        }
    }
}
