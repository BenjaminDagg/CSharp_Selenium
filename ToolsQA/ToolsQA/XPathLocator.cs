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
 * - Used to locate dynamic elements of webpage
 * 
 * ======= Axes ==========
 * - all elements in XML DOM are related to each other via a hierarchial structure
 * - Axes use relationships between nodes to locate nodes in the DOM structure
 * - ancestor: locates parent up to root of the node
 * - ancestor-orself: ancestor and the current node
 * - attribute: specifies attribute of current node
 * - child: locates children of node
 * - descendant: nodes children up to leaf node
 * - descendant or self: current node and descendant
 * - following: all nodes after current node
 * - following sibling: nodes at same level as current node and below
 * - parent: parent of current node
 * - preceding: all nodes before current node
 * - seld: current node
 */
namespace ToolsQA
{
    class XPathLocator
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(@"C:\ChromeDriver");
        }

        /*
         * XPath Contains()
         * - finds part of the value of any attribute
         * Syntax: tag_name[contains(@attribute,'value')]
         */
        [Test]
        public void TestXPathContains()
        {
            driver.Url = "https://demoqa.com/text-box";

            IWebElement nameField = driver.FindElement(By.XPath("//input[contains(@id,'userName')]"));
            nameField.SendKeys("Ben");
        }

        /*
         * XPath starts_with()
         * - finds elements with an attribute value that starts with the given string
         * - helpful if elements generated dynamically but all have the same starting characters
         * - syntax: //tag[starts-with(@attribute,'string')]
         */
        [Test]
        public void TestXPathStartsWith()
        {
            driver.Url = "https://demoqa.com/links";

            IWebElement link = driver.FindElement(By.XPath("//a[starts-with(@id,'dynamic')]"));
            link.Click();
        }

        /*
         * XPath text()
         * - located element based on text of the element
         */
        [Test]
        public void TestXPathText()
        {
            driver.Url = "https://demoqa.com/links";
            IWebElement link = driver.FindElement(By.XPath("//a[text()='Home']"));
            link.Click();
        }

        /*
         * AND operator
         * - identifies element by combining two unique ways to identify an operator
         * -Syntax: tag[@attr1 = 'val1' and @attr2 = 'value2']
         */
        [Test]
        public void TestXPathAnd()
        {
            driver.Url = "https://demoqa.com/text-box";
            IWebElement email = driver.FindElement(By.XPath("//input[@type='email' and @id='userEmail']"));
            email.SendKeys("bdagg@diamondgame.com");
        }

        /*
         * OR operator
         * - locates an element based on any of the conditions
         * - syntax: //tag[@attr1 = 'val1' or @attr2 = 'val2']
         */
        [Test]
        public void TestXPathOr()
        {
            driver.Url = "https://demoqa.com/text-box";
            IWebElement email = driver.FindElement(By.XPath("//input[@type='email' or @placeholder='name@example.com']"));
            email.Click();
        }

        /*
         * Ancestor axis
         * - syntax: tag[@attr='value']//ancestor::parent-node
         */
        [Test]
        public void TestXPathAncestor()
        {
            driver.Url = "https://demoqa.com/text-box";
            IWebElement form = driver.FindElement(By.XPath("//input[@id='userName']//ancestor::form"));
            Console.WriteLine("Parent ID: {0}", form.GetAttribute("id"));
        }


        /*
         * Child Axis
         * - finds all child nodes of current node
         * - syntax: tag[@attr='val']//child::child_node
         */
        [Test]
        public void TestXPathChild()
        {
            driver.Url = "https://demoqa.com/text-box";
            IWebElement label = driver.FindElement(By.XPath("//form[@id='userForm']//child::div[2]/div[1]/label"));
            Console.WriteLine("Found element: {0}",label.GetAttribute("id"));
        }

        /*
         * Descendant Axis
         * - gets all children and subchildren of the node
         */
        [Test]
        public void TestXPathDescendant()
        {
            driver.Url = "https://demoqa.com/radio-button";

            IWebElement input = driver.FindElement(By.XPath("//div[@class='custom-control custom-radio custom-control-inline']//descendant::input"));
            Console.WriteLine("Found element: {0}",input.GetAttribute("id"));
        }

        /*
         * Parent Axis
         * - identifies immediate parent of the current node
         * - only returns one element whereas ancestor returns all upper elements in hierarchy
         */
        [Test]
        public void TestXPathParent()
        {
            driver.Url = "https://demoqa.com/radio-button";
            IWebElement parent = driver.FindElement(By.XPath("//input[@id='impressiveRadio']//parent::div"));
            Console.WriteLine("found element: {0}", parent.GetAttribute("class"));
        }

        /*
         * Following Axis
         * - locates element after the current node
         * - syntax: //node[@attr='val']//following::node
         */
        [Test]
        public void TestXPathFollowing()
        {
            /*
            driver.Url = "https://demoqa.com/text-box";
            IList<IWebElement> elements = driver.FindElements(By.XPath("//input[@id='userEmail']//following::textarea"));
            foreach(IWebElement textarea in elements)
            {
                Console.WriteLine("found element: {0}",textarea.GetAttribute("id"));
            }
            */
            //go to sites page
            driver.Url = "https://qa-easyvend.dgcdn.net/Identity/Account/Login";
            IWebElement usernameField = driver.FindElement(By.Id("Input_Email"));
            IWebElement passwordField = driver.FindElement(By.Id("Input_Password"));
            IWebElement submitButton = driver.FindElement(By.Id("btnLogin"));

            usernameField.SendKeys("tmahoney@diamondgame.com");
            passwordField.SendKeys("Diamond1!");
            submitButton.Click();

            IWebElement sitesLink = driver.FindElement(By.CssSelector("a[href='/Site']"));
            sitesLink.Click();

            IWebElement table = driver.FindElement(By.Id("tblEntityList"));
            
            IList<IWebElement> rows = driver.FindElements(By.XPath("//table[@id='tblEntityList']//following::tr"));



            //display each row
            foreach (IWebElement row in rows)
            {
                IList<IWebElement> td = row.FindElements(By.TagName("td"));
                string data = "";
                foreach (IWebElement tdItem in td)
                {
                    data += tdItem.Text + ",";

                }
                Console.WriteLine(data);
                
            }
        }

        /*
         * Following-sibling Axis
         * - finds sibling nodes, nodes on same level as current node
         */
        [Test]
        public void TestXPathSibling()
        {
            driver.Url = "https://demoqa.com/text-box";
            IList<IWebElement> siblings = driver.FindElements(By.XPath("//div[@id='userName-wrapper']//following-sibling::div"));

            foreach(IWebElement sibling in siblings)
            {
                Console.WriteLine("Found sibling: {0}", sibling.GetAttribute("id"));
            }
        }

        /*
         * Preceding Axis
         * - finds all nodes before the current node
         */
        [Test]
        public void TestXPathPreceding()
        {
            driver.Url = "https://demoqa.com/text-box";

            IList<IWebElement> labels = driver.FindElements(By.XPath("//label[@id='permanentAddress-label']//preceding::label"));

            foreach(IWebElement label in labels)
            {
                Console.WriteLine(label.Text);
            }
        }


        [TearDown]
        public void EndTest()
        {
            
        }
    }
}
