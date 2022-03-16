using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Collections;

namespace ToolsQA
{
    class ImplicitWait
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(@"C:\ChromeDriver");
        }

        /*
         * Implicit wait
         * - for cases when the elements wont be present instantaneously
         * - driver continously retries until an emount of time passes or the element is found
         */
        [Test]
        public void TestImplicitWait()
        {
            
            driver.Url = "https://dmb-qa.dgcdn.net/Identity/Account/Login?ReturnUrl=%2F";

            IWebElement usernameInput = driver.FindElement(By.Id("Input_Email"));
            IWebElement passwordInput = driver.FindElement(By.Id("Input_Password"));
            IWebElement submitBtn = driver.FindElement(By.Id("btnLogin"));

            passwordInput.SendKeys("Diamond1!");
            submitBtn.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            IWebElement usernameError = driver.FindElement(By.Id("Input_Email-error"));
            

            Console.WriteLine("found error: {0}",usernameError.Text);
        }

        /*
         * PageLoad
         * - set time to wait for page to load
         * - exception is thrown if page doesn't load in specified time
         */
        [Test]
        public void TestPageLoad()
        {
            try
            {
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(0.1);

                driver.Url = "https://demoqa.com/browser-windows";
            }catch(Exception ex)
            {
                Console.WriteLine("Caught " + ex.Message);
            }
            

            
        }

        /*
         * SetScriptTimeout
         * - sets amount of time to wait for asynchronnous script to finish execution
         */
        [Test]
        public void TestSetupScriptTimeout()
        {
            driver.Url = "https://demoqa.com/dynamic-properties";
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(0.1);
        }

        [TearDown]
        public void EndTest()
        {

        }
    }
}
