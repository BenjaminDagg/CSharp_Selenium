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
using SeleniumExtras.PageObjects;


namespace ToolsQA
{
    internal class Homepage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[@href='/Site']")]
        public IWebElement Sites { get; set; }

        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        public void ClickSites()
        {
            Sites.Click();
        }
    }
}
