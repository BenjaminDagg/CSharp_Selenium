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

namespace ToolsQA
{

    class SiteTableItem
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Lottery { get; set; }

        public string AgentNumber { get; set; }
        public string DeviceCount { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }

        public SiteTableItem(string name, string id, string lottery, string count, string phone)
        {
            Name = name;
            ID = id;
            Lottery = lottery;
            DeviceCount = count;
            Phone = phone;

        }

        public SiteTableItem(string data)
        {
            string[] siteData = data.Split(",");
            
            Name = siteData[0];
            ID = siteData[1];
            Lottery = siteData[2];
            DeviceCount = siteData[4];
            Phone = siteData[5];
        }

        public void display()
        {
            Console.WriteLine("Name: {0}, ID: {1}, Lottery: {2}, # Devices: {3}, Phone:{4}", Name, ID, Lottery, DeviceCount, Phone);
        }
    }

    class Tables
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(@"C:\ChromeDriver");
        }

        [Test]
        public void TestGetToSitePage()
        {
            driver.Url = "https://qa-easyvend.dgcdn.net/Identity/Account/Login";
            IWebElement usernameField = driver.FindElement(By.Id("Input_Email"));
            IWebElement passwordField = driver.FindElement(By.Id("Input_Password"));
            IWebElement submitButton = driver.FindElement(By.Id("btnLogin"));

            usernameField.SendKeys("tmahoney@diamondgame.com");
            passwordField.SendKeys("Diamond1!");
            submitButton.Click();
            //Thread.Sleep(2000);
            IWebElement sitesLink = driver.FindElement(By.CssSelector("a[href='/Site']"));
            sitesLink.Click();
        }

        [Test]
        public void DisplayTable()
        {
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
            IList<IWebElement> header = table.FindElements(By.TagName("tr"));
            IWebElement body = table.FindElement(By.TagName("tbody"));
            IList<IWebElement> rows = body.FindElements(By.TagName("tr"));

            

            //display each row
            foreach(IWebElement row in rows)
            {
                IList<IWebElement> td = row.FindElements(By.TagName("td"));
                string data = "";
                foreach(IWebElement tdItem in td)
                {
                    data += tdItem.Text + ",";
                    
                }
               
                SiteTableItem site = new SiteTableItem(data);
                site.display();
            }
            
        }

        [TearDown]
        public void EndTest()
        {
            
        }
    }

    
}
