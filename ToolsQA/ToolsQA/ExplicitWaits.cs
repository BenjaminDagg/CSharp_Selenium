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
 * Explicit waits explicitly wait for conditions to be met
 * - condition could be to wait for element to exist, element to be visible etc
 * - explicit wait (smart) wait doesnt wait for maximum time
 * - if condition is med the wait is exited
 * - explicit wait only works for element which its set for unlike implicit wait which applies to all elements
 * - explicit wait can wait for any type of condition (element can be clicked, element style changed etc) whereas
 * implicit wait only checks for existence of an element (findElement)
 * - ExpectedCondition class provides possible conditions the WebDriverWait can wait for
 * 
 * fluent wait: https://www.lambdatest.com/blog/explicit-fluent-wait-in-selenium-c/
 * - lets you control max amount of time driver waits for condition to be met
 * - done by setting frequency the driver checks for element before throwing ElementNotVisibleException
 * - different from explicit wait because lets you control the polling frequency wheras its set to 250ms in explicit wait
 * - if polling frequency not specified its default to 250ms
 * - lets you ignore exception during the polling frequency with IgnoreExceptionTypes parameter
 */
namespace ToolsQA
{
    class ExplicitWaits
    {
        IWebDriver driver;

        public Func<IWebDriver, string, IWebElement> f = elementExists;

        public static IWebElement elementExists(IWebDriver d,string id)
        {
            try
            {
                IWebElement element = d.FindElement(By.Id(id));
                return element;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(@"C:\ChromeDriver");
        }

        [Test]
        public void TestExplicit()
        {
            driver.Url = "https://demoqa.com/dynamic-properties";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            
            Func<IWebDriver, IWebElement> waitForElement = new Func<IWebDriver, IWebElement>((IWebDriver d) =>
              {
                  try
                  {
                      IWebElement element = d.FindElement(By.Id("visibleAfter"));
                      return element;
                  }catch (Exception ex)
                  {
                      return null;
                  }
              });
            IWebElement dynamicElement = wait.Until(waitForElement);
            Console.WriteLine("found element: {0}", dynamicElement.Text);
        }

        [Test]
        public void TestExplicitColorChange()
        {
            driver.Url = "https://demoqa.com/dynamic-properties";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            Func<IWebDriver, IWebElement> waitForColorChange = new Func<IWebDriver, IWebElement>((IWebDriver d) =>
             {
                 IWebElement colorChange = d.FindElement(By.Id("colorChange"));

                 if (colorChange.GetCssValue("color") == "rgba(255, 255, 255, 1)"){
                     return null;
                 }
                 return colorChange;
             });

            IWebElement dynamicColorChange = wait.Until(waitForColorChange);
            Console.WriteLine("Color = {0}", dynamicColorChange.GetCssValue("color"));
        }

        [Test]
        public void TestExplicitWaitHelpers()
        {
            driver.Url = "https://demoqa.com/dynamic-properties";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            
            IWebElement dynamicElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("visibleAfter")));
            Console.WriteLine("Element is now visible: {0}",dynamicElement.Text);

            
        }

        [Test]
        public void TestExplicit2()
        {
            driver.Url = "https://demoqa.com/dynamic-properties";

            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(5));
            IWebElement dynamicElement = wait.Until(x => driver.FindElement(By.Id("visibleAfter")));
            Console.WriteLine("found element: {0}", dynamicElement.Text);
        }

        [Test]
        public void TestExplicit3()
        {
            driver.Url = "https://dmb-qa.dgcdn.net/Identity/Account/Login?ReturnUrl=%2F";

            IWebElement usernameInput = driver.FindElement(By.Id("Input_Email"));
            IWebElement passwordInput = driver.FindElement(By.Id("Input_Password"));
            IWebElement submitBtn = driver.FindElement(By.Id("btnLogin"));

            passwordInput.SendKeys("Diamond1!");
            submitBtn.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            IWebElement usernameError = wait.Until(e => driver.FindElement(By.Id("Input_Email-error")));

            Console.WriteLine("Found the error: {0}:",usernameError.Text);
        }

        [Test]
        public void TestFluentWait()
        {
            driver.Url = "https://demoqa.com/dynamic-properties";

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(3);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            IWebElement dynamicElement = fluentWait.Until(webDriver => webDriver.FindElement(By.Id("visibleAfter")));
            Console.WriteLine("Found dynamic element: {0}, {1}", dynamicElement.GetCssValue("id"), dynamicElement.Text);

        }

        [TearDown]
        public void EndTest()
        {

        }
    }
}
