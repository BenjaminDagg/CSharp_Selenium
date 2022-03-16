using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;


/*
 * WebElement represents an HTML Element
 * - HTML elements have start tag, end tag and content in between
 * - IWebElement interface performs interactions with page
 * - FindElement method of IWebDriver returns an IWebElement
 * IWebElement element = driver.FindElement(By.Id("Username"))
 * - IWebElement can be any type of HTML element
 * - all  IWebElement methods/properties can be called on it even if it may be invalid for the type of element
 */
namespace ToolsQA
{
    class WebElements
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(@"C:\ChromeDriver");
        }


        /*
         * Clear can be used on inputs and text areas to clear the value
         */
        [Test]
        public void TestClear()
        {
            driver.Url = "https://demoqa.com/text-box";

            //put text in username field
            driver.FindElement(By.Id("userName")).SendKeys("Ben Dagg");

            IWebElement usernameField = driver.FindElement(By.Id("userName"));
            usernameField.Clear();
        }

        /*
         * SendKeys sends input to an element to set its value. Accepts string as a parameter
         * element.SendKeys("text")
         */
        [Test]
        public void TestSendKeys()
        {
            driver.Url = "https://demoqa.com/text-box";

            //find username text field
            IWebElement usernameField = driver.FindElement(By.Id("userName"));
            usernameField.SendKeys("Ben Dagg");

            
        }

        /*
         * Click()
         * simulates click of an element
         */
        [Test]
        public void TestClick()
        {
            driver.Url = "https://www.youtube.com/";

            IWebElement homeButton = driver.FindElement(By.Id("logo"));
            homeButton.Click();

        }

        /*
         * Displayed
         * - determines of an element if currently being displayed or not
         */
        [Test]
        public void TestDisplayed()
        {
            driver.Url = "https://dmb-qa.dgcdn.net/Identity/Account/Login?ReturnUrl=%2FIdentity%2FAccount%2F";

            IWebElement emailError = driver.FindElement(By.Id("Input-Email-error"));
            IWebElement usernameInput = driver.FindElement(By.Id("Input_Email"));
            IWebElement submitBtn = driver.FindElement(By.Id("btnLogin"));

            bool isDisplayed = emailError.Displayed;
            Console.WriteLine("Before clicking: {0}", isDisplayed);

            submitBtn.Click();

            isDisplayed = emailError.Displayed;
            Console.WriteLine("Before clicking: {0}", isDisplayed);
        }

        /*
         * Selected
         * - returns true if checkbox, select option or radio button is selected; otherwise false
         */
        [Test]
        public void TestSelected()
        {

        }

        /*
         * Submit()
         * - same as click() if the element is within a form
         * - if current page changes the method waits for new page to load
         */
        [Test]
        public void TestSubmit()
        {
            driver.Url = "https://dmb-qa.dgcdn.net/Identity/Account/Login?ReturnUrl=%2FIdentity%2FAccount%2F";

            IWebElement usernameField = driver.FindElement(By.Id("Input_Email"));
            IWebElement passwordField = driver.FindElement(By.Id("Input_Password"));
            IWebElement submitBtn = driver.FindElement(By.Id("btnLogin"));

            usernameField.SendKeys("bdagg@diamondgame.com");
            passwordField.SendKeys("Diamond1!");

            submitBtn.Submit();
        }

        /*
         * Text {get;}
         * - gets innertext for an element and returns string value
         */
        [Test]
        public void TestText()
        {
            driver.Url = "https://dmb-qa.dgcdn.net/Identity/Account/Login?ReturnUrl=%2FIdentity%2FAccount%2F";

            IWebElement resetPassword = driver.FindElement(By.Id("resetPwd"));
            string text = resetPassword.Text;

            Console.WriteLine("Text of the linkL {0}",text);
        }

        /*
         * TagName {get;}
         * - gets HTML tag name of the element 
         * - Example: input, div, etc
         */
        [Test]
        public void TestTagName()
        {
            driver.Url = "https://dmb-qa.dgcdn.net/Identity/Account/Login?ReturnUrl=%2FIdentity%2FAccount%2F";

            IWebElement usernameField = driver.FindElement(By.Id("Input_Email"));
            IWebElement submitBtn = driver.FindElement(By.Id("btnLogin"));
            IWebElement resetPassword = driver.FindElement(By.Id("resetPwd"));

            Console.WriteLine("Username field is a <{0}>", usernameField.TagName);
            Console.WriteLine("Submit button is a <{0}>", submitBtn.TagName);
            Console.WriteLine("Reset password link is a <{0}>", resetPassword.TagName);
        }

        /*
         * GetCssValue()
         * - returns value of the given css property for an element
         * - ie color, width, etc
         */
        [Test]
        public void TestCssValue()
        {
            driver.Url = "https://dmb-qa.dgcdn.net/Identity/Account/Login?ReturnUrl=%2FIdentity%2FAccount%2F";
            IWebElement submitBtn = driver.FindElement(By.Id("btnLogin"));

            Console.WriteLine("Color: {0}", submitBtn.GetCssValue("background-color"));
            
        }

        /*
         * GetAttribute()
         * - gets the value of the attribute for an element
         * - attributes are id, name ,class
         */
        [Test]
        public void TestAttribute()
        {
            driver.Url = "https://dmb-qa.dgcdn.net/Identity/Account/Login?ReturnUrl=%2FIdentity%2FAccount%2F";

            IWebElement usernameField = driver.FindElement(By.Id("Input_Email"));

            string id = usernameField.GetAttribute("id");
            string name = usernameField.GetAttribute("name");
            string attClass = usernameField.GetAttribute("class");

            Console.WriteLine("Username field class: {0} Id: {1}, name: {2}", attClass, id, name);
        }

        /*
         * Size {get;}
         * - returns Dimension object of the width and height of the element
         */
        [Test]
        public void TestSize()
        {
            driver.Url = "https://dmb-qa.dgcdn.net/Identity/Account/Login?ReturnUrl=%2FIdentity%2FAccount%2F";

            
            IWebElement submitBtn = driver.FindElement(By.Id("btnLogin"));
            int width = submitBtn.Size.Width;
            int height = submitBtn.Size.Height;

            Console.WriteLine("Submit button width: {0} height: {1}",width,height);
        }

        /*
         * Location {get;}
         * - returns Point object representing x and y coordinate of element on screen
         */
        [Test]
        public void TestLocation()
        {
            driver.Url = "https://dmb-qa.dgcdn.net/Identity/Account/Login?ReturnUrl=%2FIdentity%2FAccount%2F";


            IWebElement submitBtn = driver.FindElement(By.Id("btnLogin"));

            int x = submitBtn.Location.X;
            int y = submitBtn.Location.Y;

            Console.WriteLine("Submit button: ({0},{1})", x, y);
        }

        [TearDown]
        public void EndTest()
        {
            
        }
    }

    
}
