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
 * Webdriver keeps track of all windows opened during the sesesion
 * - selenium keeps track of open windows via the window handle
 * -window handle is a unique string that identifies a window
 * - 2 ways to get a window handle: CurrentWindowHandle and WindowHandles
 * - CurrentWindowHandle returns handle of currently focuses window
 * - WindowHandles returns ReadOnlyCollection of all window handles opened during the session
 * 
 * - all selenoum commands go to currently focused window
 * - shift focus to another window using driver.SwitchTo().Window(handle)
 * - this switches context to that window and all commands go to that window
 * 
 * - 2 ways to close current window which is being focused driver.Close() and driver.Quit()
 * - Close() closes window which is currently focused - used to close a window selectively
 *  - switch to window then call Close() on it
 * - After closing a window you must switch to another valid window before sending commands
 * - driver.Quit() closes all windows opened in session and shuts down driver instance for further commands
 */

namespace ToolsQA
{
    class MultipleWindows
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(@"C:\ChromeDriver");
        }


        [Test]
        public void OpenMultipleWindows()
        {
            driver.Url = "https://demoqa.com/browser-windows";

            IWebElement button = driver.FindElement(By.Id("windowButton"));

            String parentWin = driver.CurrentWindowHandle;
            

            for (int i = 0; i < 5; i++)
            {
                button.Click();
                Thread.Sleep(1000);
            }
        }

        [Test]
        public void TestWindowHandles()
        {
            driver.Url = "https://demoqa.com/browser-windows";

            IWebElement button = driver.FindElement(By.Id("windowButton"));

            string parentWin = driver.CurrentWindowHandle;
            Console.WriteLine("Parent: {0}",parentWin);

            for(int i = 0; i < 5; i++)
            {
                button.Click();
            }

            List<string> handles = driver.WindowHandles.ToList();
            foreach(string handle in handles)
            {
                Console.WriteLine("Child: {0}",handle);
            }
        }

        [Test]
        public void TestContextSwitch()
        {
            driver.Url = "https://demoqa.com/browser-windows";

            IWebElement button = driver.FindElement(By.Id("windowButton"));

            string parentWin = driver.CurrentWindowHandle;

            for (int i = 0; i < 5; i++)
            {
                button.Click();
            }

            List<string> handles = driver.WindowHandles.ToList();

            foreach(string handle in handles)
            {
                if (handle != parentWin)
                {
                    driver.SwitchTo().Window(handle);
                    driver.Url = "https://google.com";
                    Thread.Sleep(1000);
                }

                
            }

        }

        [Test]
        public void TestCloseWindow()
        {
            driver.Url = "https://demoqa.com/browser-windows";

            IWebElement button = driver.FindElement(By.Id("windowButton"));

            string parentWin = driver.CurrentWindowHandle;

            for (int i = 0; i < 5; i++)
            {
                button.Click();
            }

            List<string> handles = driver.WindowHandles.ToList();
            string lastWindow = "";

            foreach (string handle in handles)
            {
                if (handle != parentWin)
                {
                    driver.SwitchTo().Window(handle);
                    driver.Url = "https://google.com";

                    lastWindow = handle;

                    Thread.Sleep(1000);
                }


            }

            //close parent
            driver.SwitchTo().Window(parentWin);
            driver.Close();

            driver.SwitchTo().Window(lastWindow);
            driver.Url = "https://toolsqa.com";



        }

        [Test]
        public void TestQuit()
        {
            driver.Url = "https://demoqa.com/browser-windows";

            IWebElement button = driver.FindElement(By.Id("windowButton"));

            string parentWin = driver.CurrentWindowHandle;

            for (int i = 0; i < 5; i++)
            {
                button.Click();
            }

            List<string> handles = driver.WindowHandles.ToList();
            

            foreach (string handle in handles)
            {
                if (handle != parentWin)
                {
                    driver.SwitchTo().Window(handle);
                    driver.Url = "https://google.com";

                   

                    Thread.Sleep(1000);
                }


            }

            driver.Quit();
        }


        [TearDown]
        public void EndTest()
        {

        }
    }
}
