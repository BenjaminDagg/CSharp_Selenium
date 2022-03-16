using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Collections;

/*
 * - IWebDriver object provides methods for finding HTML elements on a web page
 * - FindElements() and FindElement()
 * - FindElements() and FindElement() returns IWebElement object
 * - FindElements() and FindElement() take By object as parameter which is the method used to search elements
 */

namespace ToolsQA
{
    class FindElements
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(@"C:\ChromeDriver");
            
        }

        /*
         * By Id
         * - takes string parameter which is value of ID attribute of the element
         * - returns a By object to FindElement()
         * - most efficient method because most of the time IDs are unique
         * - if element is not found NoSuchElementException is raised
         */
        [Test]
        public void TestById()
        {
            driver.Url = "https://demoqa.com/text-box";

            IWebElement emailField = driver.FindElement(By.Id("userEmail"));
            Console.WriteLine("found element {0}", emailField.GetAttribute("id"));
        }

        [Test]
        public void TestByIdNotFound()
        {
            driver.Url = "https://demoqa.com/text-box";
            
            try
            {
                IWebElement emailField = driver.FindElement(By.Id("userEmail343"));
            } catch (Exception ex)
            {
                Console.WriteLine("Element not found");
            }
            
        }

        /*
         * By Name
         * - takes string as pareameter which is the value of the name attribute for the element
         * - first element with the matching name attribute is returned
         * - if no element found throws NoSuchElementException
         */
        [Test]
        public void TestByName()
        {
            driver.Url = "https://dmb-qa.dgcdn.net/Identity/Account/Login?ReturnUrl=%2FIdentity%2FAccount%2F";

            IWebElement usernameField = driver.FindElement(By.Name("Input.Email"));

            Console.WriteLine("Username field: id:{0}, name:{1}", usernameField.GetAttribute("id"),usernameField.GetAttribute("name"));
            
        }

        /*
         * By ClassName
         * - finds elements based on class attribute
         * - takes string parameter which is the value of the class attribute
         */
        [Test]
        public void TestByClassName()
        {
            driver.Url = "https://demoqa.com/automation-practice-form";
            foreach(IWebElement element in driver.FindElements(By.ClassName("mr-sm-2 form-control"))){
                Console.WriteLine(element.GetAttribute("id"));
            }
        }

        /*
         * Finds elements based on their HTML tag name
         */
        [Test]
        public void TestByTagName()
        {
            driver.Url = "https://dmb-qa.dgcdn.net/Identity/Account/Login?ReturnUrl=%2FIdentity%2FAccount%2F";

            
            IWebElement submitBtn = driver.FindElement(By.TagName("a"));
            Console.WriteLine("Found element: {0}",submitBtn.GetAttribute("id"));
            
        }

        /*
         * By LinkText and PartialLinkText
         * - find <a> elements by their link names
         * - use By.PartialLinkText to find elements by partial match of link name
         */
        [Test]
        public void TestByLinkText()
        {
            driver.Url = "https://demoqa.com/links";

            IWebElement link = driver.FindElement(By.PartialLinkText("Home"));

            Console.WriteLine("found link '{0}'", link.Text);
        }

        [Test]
        public void TestByPartialLinkText()
        {
            driver.Url = "https://demoqa.com/links";

            IWebElement link = driver.FindElement(By.PartialLinkText("Ho"));

            Console.WriteLine("found link '{0}'", link.Text);
        }

        [Test]
        public void Exercise1()
        {
            driver.Url = "https://demoqa.com/text-box";

            IWebElement name = driver.FindElement(By.Id("userName"));
            IWebElement email = driver.FindElement(By.Id("userEmail"));
            IWebElement address = driver.FindElement(By.Id("currentAddress"));
            IWebElement submit = driver.FindElement(By.Id("submit"));

            name.SendKeys("Ben Dagg");
            email.SendKeys("bdagg@gmail.com");
            address.SendKeys("123 Test Street");
            submit.Click();

        }

        [TearDown]
        public void EndTest()
        {

        }
    }
}
