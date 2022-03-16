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
    class CheckBoxAndRadiobox
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(@"C:\ChromeDriver");
        }

        /*
         * Click radio button by ID
         */
        [Test]
        public void TestClickRadio()
        {
            driver.Url = "https://demoqa.com/radio-button";

            IWebElement radio = driver.FindElement(By.XPath("//label[@for='yesRadio']"));

            radio.Click();
        }

        /*
         * IsSelected 
         * - determines if radio is selected or not
         */
        [Test]
        public void TestIsSelected()
        {
            
            driver.Url = "https://demoqa.com/radio-button";

            IList<IWebElement> radios = driver.FindElements(By.Name("like"));
            IList<IWebElement> radioLabels = driver.FindElements(By.ClassName("custom-control-label"));
            Random r = new Random();

            int randSelected = r.Next(2);
            radioLabels[randSelected].Click();
            
            if (radios[0].Selected)
            {
                Console.WriteLine("Yes radio is selected");
                radioLabels[1].Click();
            }
            else
            {
                Console.WriteLine("Impressive radio is selected");
                radioLabels[0].Click();
            }
        }

        /*
         * Get Values of radio buttons
         */
        [Test]
        public void TestRadioValues()
        {
            driver.Url = "https://demoqa.com/automation-practice-form";

            IList<IWebElement> radios = driver.FindElements(By.Name("gender"));
            IList<IWebElement> radioLabels = driver.FindElements(By.ClassName("custom-control-label"));

            for(int i = 0; i < radios.Count;i++)
            {
                string value = radios[i].GetAttribute("value");
                Console.WriteLine("Value: {0}",value);
                if (value == "Female")
                radioLabels[i].Click();
            }
        }

        /*
         * Get radio button by CssSelector
         */
        [Test]
        public void TestByCssSelector()
        {
            driver.Url = "https://demoqa.com/automation-practice-form";

            IWebElement otherRadioButton = driver.FindElement(By.CssSelector("input[value='Other']"));
            IWebElement otherRadioLabel = driver.FindElement(By.CssSelector("label[for='gender-radio-3']"));

            otherRadioLabel.Click();
        }

        //Select the unselected radio button
        [Test]
        public void Challenge1()
        {
            driver.Url = "https://demoqa.com/automation-practice-form";

            IList<IWebElement> buttons = driver.FindElements(By.Name("gender"));
            IList<IWebElement> labels = driver.FindElements(By.ClassName("custom-control-label"));
            Random random = new Random();

            int r = random.Next(buttons.Count);
            labels[r].Click();
            Thread.Sleep(2000);
            for(int i = 0; i < buttons.Count; i++)
            {
                if (!buttons[i].Selected)
                {
                    labels[i].Click();
                    break;
                }
            }
        }

        //Select 3rd radio button using ID attribute
        [Test]
        public void Challenge2()
        {
            driver.Url = "https://demoqa.com/automation-practice-form";

            IWebElement button = driver.FindElement(By.Id("gender-radio-3"));
            IWebElement label = driver.FindElement(By.CssSelector("label[for='gender-radio-3']"));

            label.Click();
        }

        //check the 2nd radio button by value
        [Test]
        public void Challenge3()
        {
            driver.Url = "https://demoqa.com/automation-practice-form";

            IList<IWebElement> buttons = driver.FindElements(By.Name("gender"));
            IList<IWebElement> labels = driver.FindElements(By.ClassName("custom-control-label"));

            for(int i = 0; i < buttons.Count; i++)
            {
                string value = buttons[i].GetAttribute("value");

                if(value == "Female")
                {
                    labels[i].Click();
                }
            }
        }

        //check radio by cssSelector
        [Test]
        public void Challenge4()
        {
            driver.Url = "https://demoqa.com/automation-practice-form";

            IList<IWebElement> buttons = driver.FindElements(By.Name("gender"));
            IList<IWebElement> labels = driver.FindElements(By.ClassName("custom-control-label"));

            for(int i = 0; i < buttons.Count; i++)
            {
                if(buttons[i].GetAttribute("value") == "Male")
                {
                    driver.FindElement(By.CssSelector("label[for='gender-radio-1']")).Click();
                }
            }
        }

        [TearDown]
        public void EndTest()
        {

        }
    }
}
