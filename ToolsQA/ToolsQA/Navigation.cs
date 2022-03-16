using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

/*
 * INavigation interface expopses ability to move forward/back in browser history
 * -access mothod by driver.Navigate().
 * 4 Methods:
 * 1) GoToUrl - navigates to a particular page. Take string URL as parameter
 * 2) Back - navigates to previous page of browser history (like click back button on browser)
 * 3) Forward - naviagate to next page in history. Like clcicking forward button
 * 4) Refresh - refreshes page. No parameters
 */

namespace ToolsQA
{
    class Navigation
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(@"C:\ChromeDriver");
            
        }

        [Test]
        public void NavigateGoToUrl()
        {
            driver.Url = "https://google.com";

            driver.Navigate().GoToUrl("https://youtube.com");
        }

        [Test]
        public void NavigateBack()
        {
            driver.Url = "https://google.com";

            driver.Navigate().GoToUrl("https://youtube.com");

            driver.Navigate().Back();
        }

        [Test]
        public void NavigateForward()
        {
            driver.Url = "https://google.com";

            driver.Navigate().GoToUrl("https://youtube.com");

            driver.Navigate().Back();

            driver.Navigate().Forward();
        }

        [Test]
        public void NavigateRefresh()
        {
            driver.Url = "https://google.com";

            for(int i = 0; i < 5; i++)
            {
                
                driver.Navigate().Refresh();
                System.Threading.Thread.Sleep(1000);
            }
        }

        [Test]
        public void NavigateExercise1()
        {
            driver.Url = "https://dmb-qa.dgcdn.net/Identity/Account/Login?ReturnUrl=%2FIdentity%2FAccount%2F";

            //click registration link
            driver.FindElement(By.Id("resetPwd")).Click();

            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().Back();

            driver.Navigate().Refresh();
        }

        [TearDown]
        public void EndTest()
        {

        }
    }
}
