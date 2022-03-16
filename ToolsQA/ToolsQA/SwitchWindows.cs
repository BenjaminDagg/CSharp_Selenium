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
 * - used when element is opened in a new popup window
 * - new HTML page opens in a new context
 * - need top switch context to new window then communicate with elements in new window
 * SwitchTo() commands
 * - Alert(): dwitches to current dialog box
 * - Frame() switches focus to frame by index
 * - DefaultContent() switches to first frame on page or main document
 * - ParentFrame() switches focus to parent frame of current frame
 * - Window() switches to the window with given name
 * 
 * [TestInitialize] annotation runs Setup() before each test method in the class
 */


namespace ToolsQA
{
    class SwitchWindows
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(@"C:\ChromeDriver");
        }


        /*
         * Alert is a popup window shown by using javascript alert() method
         */
        [Test]
        public void TestAlert()
        {
            driver.Url = "https://demoqa.com/alerts";

            IWebElement alertButton = driver.FindElement(By.Id("alertButton"));
            alertButton.Click();

            IAlert alert = driver.SwitchTo().Alert();
            Thread.Sleep(2000);
            alert.Accept();
        }

        //alert pops up after 5 seconds
        [Test]
        public void TestAlertWait()
        {
            driver.Url = "https://demoqa.com/alerts";

            IWebElement alertButton = driver.FindElement(By.Id("timerAlertButton"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            alertButton.Click();
            IAlert alert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

            alert.Accept();
        }


        //text displays alert result
        [Test]
        public void TestAlertWait2()
        {
            driver.Url = "https://demoqa.com/alerts";

            IWebElement alertButton = driver.FindElement(By.Id("confirmButton"));
            alertButton.Click();
            
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(5));
            IAlert alert = driver.SwitchTo().Alert();
           
            alert.Accept();
            IWebElement alertResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("confirmResult")));

            Console.WriteLine(alertResult.Text);
        }

        [Test]
        public void TestAlertTextBox()
        {
            driver.Url = "https://demoqa.com/alerts";

            IWebElement alertButton = driver.FindElement(By.Id("promtButton"));

            alertButton.Click();
            IAlert prompt = driver.SwitchTo().Alert();

            prompt.SendKeys("test");

            prompt.Accept();

            WebDriverWait promptResWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement promptRes = promptResWait.Until(e => e.FindElement(By.Id("promptResult")));
            Console.WriteLine(promptRes.Text);
        }

        [Test]
        public void TestFrame()
        {
            driver.Url = "http://the-internet.herokuapp.com/nested_frames";

            /*
            //driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame(0);
            IWebElement header = driver.FindElement(By.Id("sampleHeading"));
            Console.WriteLine(header.Text);
            */
            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame(1);
            driver.SwitchTo().Frame(1);
            IWebElement body = driver.FindElement(By.TagName("body"));
            Console.WriteLine(body.Text);
           
        }

        /*https://www.lambdatest.com/blog/selenium-c-tutorial-handling-multiple-browser-windows/
         * A unique id called handle is assigned to a window when a new instance is created
         * - this is sued to identify browser windows
         * - handles are unique and used by slenium to switch between windows
         * - switchTo command switches context between browser windows
         */
        [Test]
        public void TestSwitchToWindow()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            string newWindowUrl = "https://demoqa.com/sample";
            int windowCount = driver.WindowHandles.Count;

            IWebElement newWindowButton = driver.FindElement(By.Id("windowButton"));

            newWindowButton.Click();
            windowCount = driver.WindowHandles.Count;
            Console.WriteLine("Window count: {0}",windowCount);

            string newWindowHandle = driver.WindowHandles[1];
            Console.WriteLine("New window title: {0}",driver.SwitchTo().Window(newWindowHandle).Url);

            driver.SwitchTo().Window(newWindowHandle);
            IWebElement header = driver.FindElement(By.Id("sampleHeading"));

            Console.WriteLine("New window header: {0}",header.Text);

            //close new window
            Thread.Sleep(3000);
            driver.SwitchTo().Window(newWindowHandle).Close();

            driver.SwitchTo().Window(driver.WindowHandles[0]);
            
        }

        [Test]
        public void TestSwitchTab()
        {
            string baseUrl = "http://the-internet.herokuapp.com/windows";
            string expectedNewTabUrl = "http://the-internet.herokuapp.com/windows/new";
            driver.Url = baseUrl;
            IWebElement button = driver.FindElement(By.XPath("//a[@href='/windows/new']"));
            button.Click();

            string newTabHanle = driver.WindowHandles[1];
            Console.WriteLine("New tab: {0}", driver.SwitchTo().Window(newTabHanle).Title);

            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Thread.Sleep(1000);

            driver.SwitchTo().Window(newTabHanle).Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        

        [TearDown]
        public void EndTest()
        {
            
        }
    }
}
