using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace ToolsQA
{
    class NUnitTest
    {
        IWebDriver driver;


        /*
         * Initialize browser. [Setup] 
         * Setup method runs once before every test
         */
        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(@"C:\ChromeDriver");
           
        }

        /*
         * Open the browser
         */
        [Test]
        public void OpenAppTest()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            
            //gets url
            string url = driver.Url;
            Console.WriteLine("Current URL: {0}, Length: {1}",url, url.Length);

            //gets current page title
            string title = driver.Title;
            Console.WriteLine("Title: {0}, Length: {1}",title, title.Length);

            //gets page source code
            string source = driver.PageSource;
            Console.WriteLine("source length: {0}, source: {1}",source.Length, source);
        }

        [Test]
        public void CloseAllWindowsTest()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            driver.FindElement(By.Id("windowButton")).Click();
        }


        /*
         * Close browser
         * Teardown runs once after every test
         */
        [TearDown]
        public void EndTest()
        {
            //closes only current window the IWebDriver is controlling. 
            //quit browser if its the last window open
            driver.Close();

            //closes all windows
            //driver.Quit();
        }

       
    }
}
