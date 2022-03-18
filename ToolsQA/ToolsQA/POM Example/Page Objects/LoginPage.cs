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
    internal class LoginPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "Input_Email")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "Input_Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "btnLogin")]
        public IWebElement Submit { get; set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }

        public Homepage Login(string username, string password)
        {
            Username.SendKeys(username);
            Password.SendKeys(password);
            Submit.Click();

            return new Homepage(driver);
        }
    }
}
