using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;

/*
 * To perform actions on Dropdown and Selects import Selenium.Support.UI
 * SelectElement class performs actions on select and multiselect dropdowns
 */

namespace ToolsQA
{
    class DropdownAndSelect
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(@"C:\ChromeDriver");
        }

        /*
         * SelectElement class performs actions on drodown menus
         * SelectElement object = new SelectElement(IWebElement select)
         */
        [Test]
        public void SelectTest()
        {
            driver.Url = "https://demoqa.com/select-menu";

            IWebElement element = driver.FindElement(By.Id("oldSelectMenu"));
            SelectElement sel = new SelectElement(element);

        }

        /*
         * SelectByText
         * - takes string parameter which is one of the options in the select menu
         */
        [Test]
        public void TestSelectByText()
        {
            driver.Url = "https://demoqa.com/select-menu";

            IWebElement element = driver.FindElement(By.Id("oldSelectMenu"));
            SelectElement select = new SelectElement(element);

            select.SelectByText("Violet");
        }

        /*
         * SelectByIndex
         * - selects the index # of the option in the menu
         */
        [Test]
        public void TestSelectByIndex()
        {
            driver.Url =  "https://demoqa.com/select-menu";
            
            IWebElement element = driver.FindElement(By.Id("oldSelectMenu"));
            
            SelectElement select = new SelectElement(element);

            select.SelectByIndex(7);
            
        }

        /*
         * SelectByValue
         * - selects option based on value
         * - takes string parameter which is the value of the option
         */
        [Test]
        public void TestSelectByValue()
        {
            driver.Url = "https://demoqa.com/select-menu";

            IWebElement element = driver.FindElement(By.Id("oldSelectMenu"));

            SelectElement select = new SelectElement(element);

            select.SelectByValue("3");
        }

        /*
         * SelectElement.Option
         * - gets array of IWebElements representing options of select
         * 
         */
        [Test]
        public void TestSelectOptions()
        {
            driver.Url = "https://demoqa.com/select-menu";

            IWebElement element = driver.FindElement(By.Id("oldSelectMenu"));

            SelectElement select = new SelectElement(element);

            IList<IWebElement> options = select.Options;
            
            Console.WriteLine("Number of options: {0}",options.Count);
            foreach(IWebElement option in options)
            {
                Console.WriteLine("Option: {0}", option.GetAttribute("text"));
            }
        }

        /*
         * IsMultiple
         * - determines if select is multiple select
         */
        [Test]
        public void TestIsMultiple()
        {
            driver.Url = "https://demoqa.com/select-menu";
            IWebElement element = driver.FindElement(By.Id("cars"));
            SelectElement select = new SelectElement(element);

            Console.WriteLine("Ismultiple = {0}", select.IsMultiple);
        }

        //select multiple options in a multi select
        [Test]
        public void TestSelectMultiple()
        {
            driver.Url = "https://demoqa.com/select-menu";
            IWebElement element = driver.FindElement(By.Id("cars"));
            SelectElement select = new SelectElement(element);

            select.SelectByValue("saab");
            select.SelectByText("Opel");
        }

        //test deselect all
        [Test]
        public void TestDeselectAll()
        {
            driver.Url = "https://demoqa.com/select-menu";
            IWebElement element = driver.FindElement(By.Id("cars"));
            SelectElement select = new SelectElement(element);

            select.SelectByValue("saab");
            select.SelectByText("Opel");

            Thread.Sleep(2000);

            select.DeselectAll();
        }

        //test deselect by index
        [Test]
        public void TestDeselectByIndex()
        {
            driver.Url = "https://demoqa.com/select-menu";
            IWebElement element = driver.FindElement(By.Id("cars"));
            SelectElement select = new SelectElement(element);

            select.SelectByValue("saab");
            select.SelectByText("Opel");

            Thread.Sleep(2000);

            select.DeselectByIndex(2);
        }

        //test deselect by value
        [Test]
        public void TestDeselectByValue()
        {
            driver.Url = "https://demoqa.com/select-menu";
            IWebElement element = driver.FindElement(By.Id("cars"));
            SelectElement select = new SelectElement(element);

            select.SelectByValue("saab");
            select.SelectByText("Opel");

            Thread.Sleep(2000);

            select.DeselectByValue("opel");
        }

        [TearDown]
        public void EndTest()
        {
            
        }
    }
}
